using System;
using System.Numerics;

namespace PrimeGen
{
	public interface IPrimeSource
	{
		BigInteger GetPrime(long index);
		BigInteger NextPrime(BigInteger number, out long index);
	}
}
