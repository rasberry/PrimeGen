using System;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrimeGen;

namespace test
{
	[TestClass]
	public class PrimeTest
	{
		[TestMethod]
		public void PrimeSieveTest1()
		{
			var p = new PrimeSieve();
			RunPrimeTest(p);
		}

		[TestMethod]
		public void PrimePascalTest1()
		{
			var p = new PrimePascal();
			RunPrimeTest(p);
		}

		static void RunPrimeTest(IPrimeSource prime)
		{
			BigInteger p = 0;
			for(int c=0; c<1000; c++) {
				p = prime.NextPrime(p);
				int check = FirstPrimes.List[c];
				Assert.AreEqual(p,check);
			}
		}
	}
}
