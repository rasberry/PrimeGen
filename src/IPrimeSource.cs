using System;
using System.Numerics;

namespace PrimeGen
{
	public interface IPrimeSource
	{
		BigInteger NextPrime(BigInteger number);
	}
}
