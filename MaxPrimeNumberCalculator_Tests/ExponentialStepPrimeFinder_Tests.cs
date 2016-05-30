#region Copyright text
// Copyright (c) 2016-2016 OSIsoft, LLC. All rights reserved.
// 
// THIS SOFTWARE CONTAINS CONFIDENTIAL INFORMATION AND TRADE SECRETS OF
// OSIsoft, LLC. USE, DISCLOSURE, OR REPRODUCTION IS PROHIBITED WITHOUT
// THE PRIOR EXPRESS WRITTEN PERMISSION OF OSIsoft, LLC.
// 
// RESTRICTED RIGHTS LEGEND
// Use, duplication, or disclosure by the Government is subject to restrictions
// as set forth in subparagraph (c)(1)(ii) of the Rights in Technical Data and
// Computer Software clause at DFARS 252.227.7013
// 
// OSIsoft, LLC
// 777 Davis Street, Suite 250, San Leandro CA 94577
#endregion

using System;
using MaxPrimeNumberCalculator.Interfaces;
using MaxPrimeNumberCalculator.PrimeNumberFinders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MaxPrimeNumberCalculator_Tests
{
    [TestClass]
    public class ExponentialStepPrimeFinder_Tests
    {
        [TestMethod]
        public void StepPrimeFinder_GetNextLargestPrime_Increasing()
        {
            var mockPrimeChecker = new Mock<IPrimeChecker>();
            //Mock out the prime checker to always return true
            mockPrimeChecker.Setup(mpc => mpc.IsPrime(It.IsAny<ulong>())).Returns(true);
            var primeFinder = new ExponentialStepPrimeFinder(5, 5, mockPrimeChecker.Object);

            var primeOne = primeFinder.GetNextLargestPrime();
            var primeTwo = primeFinder.GetNextLargestPrime();
            var primeThree = primeFinder.GetNextLargestPrime();

            //Assert primes are increasing
            Assert.IsTrue(primeTwo > primeOne);
            Assert.IsTrue(primeThree > primeTwo);
        }
    }
}
