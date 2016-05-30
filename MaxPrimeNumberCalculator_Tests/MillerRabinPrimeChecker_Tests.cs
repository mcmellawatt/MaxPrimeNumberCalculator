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
using System.Numerics;
using MaxPrimeNumberCalculator.PrimeCheckers;
using MaxPrimeNumberFinder;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaxPrimeNumberCalculator_Tests
{
    [TestClass]
    public class MillerRabinPrimeChecker_Tests
    {
        [TestMethod]
        public void MillerRabinPrimeChecker_PrimesTrue()
        {
            //TODO: Figure out a better way to test prime checker accuracy
            //This seems like too small of a sample size
            var primes = new List<BigInteger>() { 3, 5, 7, 11, 13, BigInteger.Parse("23068278450492279978142282436801438003027183786568253891779370669031979884395319015628722249011509958662425668793163832507842696434207336031265766822958928167380376428377545748116494965521995163965083721") };
            var primeChecker = new MillerRabinPrimeChecker();
            foreach (var prime in primes)
            {
                Assert.IsTrue(primeChecker.IsPrime(prime));
            }
        }

        [TestMethod]
        public void MillerRabinPrimeChecker_NonPrimesFalse()
        {
            var primes = new List<BigInteger>() { 4, 6, 8, 9, 10 };
            var primeChecker = new MillerRabinPrimeChecker();
            foreach (var prime in primes)
            {
                Assert.IsFalse(primeChecker.IsPrime(prime));
            }
        }
    }
}
