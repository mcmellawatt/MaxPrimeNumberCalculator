using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MaxPrimeNumberCalculator.Web_Service;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MaxPrimeNumberCalculator_Tests
{
    [TestClass]
    public class PrimeNumberSignalRHub_Tests
    {
        [TestMethod]
        public void PrimeNumberSignalRHub_StartPrimeCalculation_TimerUpdated()
        {
            int timerUpdatedCount = 0;
            var timeToCalculate = 5; //Set hub to calculate for 5 seconds
            var hub = new PrimeNumberSignalRHub(timeToCalculate);

            var mockClients = new Mock<IHubCallerConnectionContext<dynamic>>();
            hub.Clients = mockClients.Object;
            dynamic caller = new ExpandoObject();

            var resetEvent = new AutoResetEvent(false);

            caller.updateTimer = new Action<string>((name) => {
                ++timerUpdatedCount;
                if (timerUpdatedCount == timeToCalculate)
                    resetEvent.Set();
            });

            mockClients.Setup(m => m.Caller).Returns((ExpandoObject)caller);
            hub.StartPrimeCalculation();
            resetEvent.WaitOne(6000);

            Assert.AreEqual(timeToCalculate, timerUpdatedCount);
        }
    }
}
