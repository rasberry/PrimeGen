using System;
using System.Numerics;

namespace PrimeGen
{
	public class BitsEratosthenes : IPrimeSource, IDisposable
	{
		public BigInteger NextPrime(BigInteger number)
		{
			Init();
			//TODO starting from anwhere is kind of a problem
			//need to still mark off all of the previous primes < Start
			//.. so where to put that data ?
			//i think you have run through all the previous primes.. so
			//alterntive (to storing everyting) would be to record primes and replay them on each block
			//

			return BigInteger.Zero;
		}

		void Init()
		{
			if (dba != null) { return; }
			long size = Options.TargetSize;
			if (size < 1) {
				size = (long)(Options.End - Options.Start);
			}

			dba = new DiskBitArray(Options.OutputFile,size);
			Current = Options.Start;
		}

		DiskBitArray dba = null;
		BigInteger Current = BigInteger.Zero;

		public void Dispose()
		{
			if (dba != null) {
				dba.Dispose();
			}
		}
	}
}
