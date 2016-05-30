using System.Timers;
using Microsoft.AspNet.SignalR;

namespace MaxPrimeNumberCalculator.Web_Service
{
    public class PrimeNumberSignalRHub : Hub
    {
        private int _timeToCalculate;
        private bool _maxTimeReached = false;

        public PrimeNumberSignalRHub(int timeToCalculate = 60)
        {
            _timeToCalculate = timeToCalculate;
        }

        public void StartPrimeCalculation()
        {
            UpdateTimer();
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
    }
}
