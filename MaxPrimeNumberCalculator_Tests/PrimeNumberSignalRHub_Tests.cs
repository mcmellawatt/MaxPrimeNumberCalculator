using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MaxPrimeNumberCalculator.Interfaces;
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
            //Mock largest prime finder to always return 11
            var largestPrimeFinder = new Mock<ILargestPrimeFinder>();
            const int mockLargestPrime = 11;
            largestPrimeFinder.Setup(lpf => lpf.GetNextLargestPrime()).Returns(mockLargestPrime);

            var timeToCalculate = 5; //Set hub to calculate for 5 seconds
            var hub = new PrimeNumberSignalRHub(largestPrimeFinder.Object, timeToCalculate);

            var mockClients = new Mock<IHubCallerConnectionContext<dynamic>>();
            hub.Clients = mockClients.Object;
            dynamic caller = new ExpandoObject();

            var resetEvent = new AutoResetEvent(false);

            int timerUpdatedCount = 0;
            caller.updateTimer = new Action<string>((name) => {
                ++timerUpdatedCount;
                if (timerUpdatedCount == timeToCalculate)
                    resetEvent.Set(); //Timer has elapsed, set reset event
            });

            var receivedPrime = string.Empty;
            caller.addPrimeNumber = new Action<string>((prime) => {
                receivedPrime = prime;
            });

            mockClients.Setup(m => m.Caller).Returns((ExpandoObject)caller);
            hub.StartPrimeCalculation();
            resetEvent.WaitOne(6000);  //Wait an extra second (5+1) just for some extra padding

            //Assert that timer was updated properly
            Assert.AreEqual(timeToCalculate, timerUpdatedCount);
            //Assert that the mocked prime number was received
            Assert.IsTrue(receivedPrime.Equals(mockLargestPrime.ToString(), StringComparison.Ordinal));
            //Assert that the mocked large prime finder was used
            largestPrimeFinder.Verify(lpf => lpf.GetNextLargestPrime(), Times.AtLeastOnce);
        }
    }
}
