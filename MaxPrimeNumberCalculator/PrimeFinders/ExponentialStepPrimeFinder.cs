using System.Numerics;
using MaxPrimeNumberCalculator.Interfaces;

namespace MaxPrimeNumberCalculator.PrimeNumberFinders
{
    public class ExponentialStepPrimeFinder : ILargestPrimeFinder
    {
        private readonly IPrimeChecker _primeChecker;
        private readonly ulong _stepFactor;
        private BigInteger _stepSize;
        private BigInteger _currentValue = 2;

        public ExponentialStepPrimeFinder(ulong stepFactor, ulong stepSize, IPrimeChecker primeChecker)
        {
            _stepFactor = stepFactor;
            _stepSize = stepSize;
            _primeChecker = primeChecker;
        }

        public BigInteger GetNextLargestPrime()
        {
            _currentValue += _stepSize;

            while (!_primeChecker.IsPrime(_currentValue))
                --_currentValue;

            _stepSize *= _stepFactor;

            return _currentValue;
        }
    }
}
