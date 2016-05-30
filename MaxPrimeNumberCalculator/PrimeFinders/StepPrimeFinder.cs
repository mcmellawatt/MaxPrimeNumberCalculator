using MaxPrimeNumberCalculator.Interfaces;

namespace MaxPrimeNumberCalculator.PrimeNumberFinders
{
    public class StepPrimeFinder : ILargestPrimeFinder
    {
        private readonly IPrimeChecker _primeChecker;
        private readonly ulong _stepSize;
        private ulong _currentValue = 2;

        public StepPrimeFinder(ulong stepFactor, ulong stepSize, IPrimeChecker primeChecker)
        {
            _stepSize = stepSize;
            _primeChecker = primeChecker;
        }

        public ulong GetNextLargestPrime()
        {
            _currentValue += _stepSize;

            while (!_primeChecker.IsPrime(_currentValue))
                --_currentValue;

            return _currentValue;
        }
    }
}
