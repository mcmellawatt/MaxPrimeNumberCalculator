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
using System.Collections.Generic;
using MaxPrimeNumberCalculator.PrimeCheckers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaxPrimeNumberCalculator_Tests
{
    [TestClass]
    public class TrialDivisionPrimeChecker_Tests
    {
        [TestMethod]
        public void TrialDivisionPrimeChecker_PrimesTrue()
        {
            //TODO: Figure out a better way to test prime checker accuracy
            //This seems like too small of a sample size
            var primes = new List<ulong>() {3, 5, 7, 11, 13};
            var primeChecker = new TrialDivisionPrimeChecker();
            foreach (var prime in primes)
            {
                Assert.IsTrue(primeChecker.IsPrime(prime));
            }
        }

        [TestMethod]
        public void TrialDivisionPrimeChecker_NonPrimesFalse()
        {
            var primes = new List<ulong>() { 4, 6, 8, 9, 10 };
            var primeChecker = new TrialDivisionPrimeChecker();
            foreach (var prime in primes)
            {
                Assert.IsFalse(primeChecker.IsPrime(prime));
            }
        }
    }
}
