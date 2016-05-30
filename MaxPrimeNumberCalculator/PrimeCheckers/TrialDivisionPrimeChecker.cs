using System.Numerics;
using MaxPrimeNumberCalculator.Interfaces;

namespace MaxPrimeNumberCalculator.PrimeCheckers
{
    public class TrialDivisionPrimeChecker : IPrimeChecker
    {
        //Basic implementation idea inspired by RosettaCode
        //https://rosettacode.org/wiki/Primality_by_trial_division#C.23
        public bool IsPrime(BigInteger primeCandidate)
        {
            if (primeCandidate <= 1)
                return false;

            for (BigInteger i = 2; i * i <= primeCandidate; i++)
            {
                if (primeCandidate % i == 0)
                    return false;
            }

            return true;
        }
    }
}
