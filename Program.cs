using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PrimeGen
{
	class Program
	{
		static void Main(string[] args)
		{
			//Stopwatch sw = new Stopwatch();
			//sw.Start();
			BigInteger top = new BigInteger(uint.MaxValue);

			for(BigInteger i=top; i<top*top; i++)
			{
				bool isPrime = IsPrime(i);
				if (isPrime) { Console.WriteLine(i); }
			}
			//Console.WriteLine(sw.ElapsedMilliseconds);
			//sw.Restart();
			//for(ulong i=1; i<uint.MaxValue; i++)
			//{
			//	bool isPrime = IsPrime(i);
			//	if (isPrime) { Console.WriteLine(i); }
			//}
			//Console.WriteLine(sw.ElapsedMilliseconds);
		}

		//n*ln(n) + n*(ln(ln(n)) - 1)
		//and less than
		//n*ln(n) + n*ln(ln(n))

		static bool IsPrime(BigInteger n)
		{
			BigInteger r = 0;
			BigInteger num = n;
			BigInteger cur = 1;
			//Console.Write(cur);
			while (r < n/2) {
				r += 1;
				cur = cur * num / r;
				if (cur % n != 0) { return false; }
				//Console.Write(" "+cur+"("+(cur%n)+")");
				num -= 1;
			}
			return true;
		}

		//static bool IsPrime(ulong n)
		//{
		//	ulong r = 0;
		//	ulong num = n;
		//	ulong cur = 1;
		//	Console.Write(cur);
		//	while (r < n/2) {
		//		r += 1;
		//		cur = cur * num / r;
		//		Console.Write(" "+cur);
		//		if (cur % n != 0) { Console.WriteLine(""); return false; }
		//		num -= 1;
		//	}
		//	Console.WriteLine(""); 
		//	return true;
		//}
	}
}

//http://stackoverflow.com/questions/15580291/how-to-efficiently-calculate-a-row-in-pascals-triangle
//def comb_row(n):
//   r = 0
//   num = n
//   cur = 1
//   yield cur
//   while r <= n:
//	  r += 1  
//	  cur = (cur* num)/r
//	  yield cur
//	  num -= 1
