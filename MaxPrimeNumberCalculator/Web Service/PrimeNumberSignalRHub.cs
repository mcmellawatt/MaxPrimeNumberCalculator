using System.Timers;
using MaxPrimeNumberCalculator.Interfaces;
using Microsoft.AspNet.SignalR;

namespace MaxPrimeNumberCalculator.Web_Service
{
    public class PrimeNumberSignalRHub : Hub
    {
        private readonly ILargestPrimeFinder _largestPrimeFinder;
        private readonly int _timeToCalculate;
        private bool _maxTimeReached = false;
        private ulong _largestPrimeNumber;

        public PrimeNumberSignalRHub(ILargestPrimeFinder largestPrimeFinder, int timeToCalculate = 60)
        {
            _largestPrimeFinder = largestPrimeFinder;
            _timeToCalculate = timeToCalculate;
        }

        public void StartPrimeCalculation()
        {
            UpdateTimer();
            CalculatePrimes();
        }

        /// <summary>
        /// Updates the timer in the SignalR clients
        /// </summary>
        private void UpdateTimer()
        {
            //Create and start the timer to update the client
            //This will run on its own thread
            var timer = new Timer(1000);
            var secondsElapsed = 0;

            timer.Elapsed += (sender, args) =>
            {
                if (++secondsElapsed == _timeToCalculate)
                {
                    _maxTimeReached = true;
                    timer.Stop();
                }

                Clients.Caller.updateTimer(secondsElapsed.ToString());
            };

            timer.Start();
        }

        private void CalculatePrimes()
        {
            while (!_maxTimeReached)
            {
                _largestPrimeNumber = _largestPrimeFinder.GetNextLargestPrime();
                Clients.Caller.addPrimeNumber(_largestPrimeNumber.ToString());
            }
        }
    }
}
