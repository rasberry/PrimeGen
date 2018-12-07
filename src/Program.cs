using System;
using System.Diagnostics;
using System.Numerics;

namespace PrimeGen
{
	class Program
	{
		static void Main(string[] args)
		{
			////var gen = new PrimeSieve();
			var gen = new PrimePascal();
			long count = 1000;
			BigInteger p = 0;
			while(--count >= 0) {
				p = gen.NextPrime(p);
				Console.WriteLine(p);
			}

			//var gen = new PrimePascal();
			//var start = BigInteger.Parse("441123");
			//Stopwatch sw = Stopwatch.StartNew();
			//gen.NextPrime(start);
			//Console.WriteLine("1 "+sw.ElapsedMilliseconds);
			//sw.Restart();
			//gen.NextPrime1(start);
			//Console.WriteLine("2 "+sw.ElapsedMilliseconds);
		}
	}
}
