using System;

namespace PrimeGen
{
	class Program
	{
		static void Main(string[] args)
		{
			var gen = new PrimeSieve();
			long last = 1000;
			for(long p=0; p<last; p++) {
				var n = gen.GetPrime(p);
				Console.WriteLine(n);
			}
		}
	}
}
