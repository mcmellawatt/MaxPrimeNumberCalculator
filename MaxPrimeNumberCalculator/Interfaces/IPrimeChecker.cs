using System.Numerics;

namespace MaxPrimeNumberCalculator.Interfaces
{
    public interface IPrimeChecker
    {
        /// <summary>
        /// Checks of a given number is prime
        /// </summary>
        /// <param name="primeCandidate">Prime candidate</param>
        /// <returns>True if prime, false if not</returns>
        bool IsPrime(BigInteger primeCandidate);
    }
}
