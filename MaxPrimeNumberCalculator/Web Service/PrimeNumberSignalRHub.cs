using Microsoft.AspNet.SignalR;

namespace MaxPrimeNumberCalculator.Web_Service
{
    public class PrimeNumberSignalRHub : Hub
    {
        public void StartPrimeCalculation()
        {
            UpdateTimer();
        }

        private void UpdateTimer()
        {
            Clients.Caller.updateTimer(60);
        }
    }
}
