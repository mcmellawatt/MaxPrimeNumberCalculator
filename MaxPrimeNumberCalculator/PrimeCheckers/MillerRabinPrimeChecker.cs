using System.Numerics;
using System.Security.Cryptography;
using MaxPrimeNumberCalculator.Interfaces;

namespace MaxPrimeNumberFinder
{
    public class MillerRabinPrimeChecker : IPrimeChecker
    {
        /*
          Basic implementation idea sourced from RosettaCode example.
          https://rosettacode.org/wiki/Miller%E2%80%93Rabin_primality_test

          Pseudocode from Wikipedia
          ------------------------------------------------------------------------
            write n − 1 as 2r·d with d odd by factoring powers of 2 from n − 1
                WitnessLoop: repeat k times:
                   pick a random integer a in the range [2, n − 2]
                   x ← ad mod n
                   if x = 1 or x = n − 1 then
                      continue WitnessLoop
                   repeat r − 1 times:
                      x ← x2 mod n
                      if x = 1 then
                         return composite
                      if x = n − 1 then
                         continue WitnessLoop
                   return composite
                return probably prime
        */
        public bool IsPrime(BigInteger primeCandidate)
        {
            if (primeCandidate == 2 || primeCandidate == 3)
                return true;
            if (primeCandidate < 2 || primeCandidate % 2 == 0)
                return false;

            BigInteger d = primeCandidate - 1;
            int s = 0;

            while (d % 2 == 0)
            {
                d /= 2;
                s += 1;
            }

            // There is no built-in method for generating random BigInteger values.
            // Instead, random BigIntegers are constructed from randomly generated
            // byte arrays of the same length as the source.
            RandomNumberGenerator rng = RandomNumberGenerator.Create();
            byte[] bytes = new byte[primeCandidate.ToByteArray().LongLength];
            BigInteger a;

            // Witness loop.  Do 64 iterations based on this logic:
            // "Each iteration of Rabin-Miller reduces the odds that the number is composite by a factor of 1/4.
            // So after 64 iterations, there is only 1 chance in 2 ^ 128 that the number is composite."
            // For this application, it was decided that is enough certainty.  If absolute certainty is a must, the a deterministic prime checker
            // can be used instead. 
            //http://stackoverflow.com/questions/6325576/how-many-iterations-of-rabin-miller-should-i-use-for-cryptographic-safe-primes
            for (int i = 0; i < 64; i++)
            {
                do
                {
                    rng.GetBytes(bytes);
                    a = new BigInteger(bytes);
                }
                while (a < 2 || a >= primeCandidate - 2);

                BigInteger x = BigInteger.ModPow(a, d, primeCandidate);
                if (x == 1 || x == primeCandidate - 1)
                    continue;

                for (int r = 1; r < s; r++)
                {
                    x = BigInteger.ModPow(x, 2, primeCandidate);
                    if (x == 1)
                        return false;
                    if (x == primeCandidate - 1)
                        break;
                }

                if (x != primeCandidate - 1)
                    return false;
            }

            return true;
        }
    }
}