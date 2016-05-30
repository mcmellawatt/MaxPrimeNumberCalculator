using System.Security.Cryptography.X509Certificates;

namespace MaxPrimeNumberCalculator.Interfaces
{
    public interface ILargestPrimeFinder
    {
        /// <summary>
        /// Retrieves the next largest prime using the implemented algorithm
        /// </summary>
        /// <returns>Next largest prime number</returns>
        ulong GetNextLargestPrime();
    }
}
