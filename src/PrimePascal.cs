using System;
using System.Numerics;

namespace PrimeGen
{
	public class PrimePascal : IPrimeSource
	{
		public BigInteger NextPrime(BigInteger number)
		{
			if (number < 2) {
				return 2;
			}

			BigInteger test = number.IsEven
				? number + 1
				: number + 2
			;

			bool isPrime = false;
			while(!isPrime)
			{
				isPrime = true;
				BigInteger mid = test/2;
				BigInteger last = test;
				for(BigInteger p=2; p<mid; p++)
				{
					//https://en.wikipedia.org/wiki/Pascal's_triangle#Calculating_a_row_or_diagonal_by_itself
					// BigInteger num = last * (test + 1 - p) / p;
					//this formulation is ~2x faster
					BigInteger num = last * ((test + 1) / p - 1);
					last = num;

					BigInteger rem;
					BigInteger.DivRem(num,test,out rem);

					if (rem != 0) {
						isPrime = false;
						break; //not a prime
					}
				}
				if (!isPrime) {
					test += 2;
				}
			}
			return test;
		}

		public BigInteger NextPrime1(BigInteger number)
		{
			if (number < 2) {
				return 2;
			}

			BigInteger test = number.IsEven
				? number + 1
				: number + 2
			;

			bool isPrime = false;
			while(!isPrime)
			{
				isPrime = true;
				BigInteger mid = test/2;
				BigInteger last = test;
				for(BigInteger p=2; p<mid; p++)
				{
					//https://en.wikipedia.org/wiki/Pascal's_triangle#Calculating_a_row_or_diagonal_by_itself
					//BigInteger num = last * (test + 1 - p) / p;
					BigInteger num = last * ((test + 1) / p - 1);
					last = num;

					BigInteger rem;
					BigInteger.DivRem(num,test,out rem);

					if (rem != 0) {
						isPrime = false;
						break; //not a prime
					}
				}
				if (!isPrime) {
					test += 2;
				}
			}
			return test;
		}
	}
}
