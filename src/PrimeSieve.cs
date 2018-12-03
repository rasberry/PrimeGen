using System;
using System.Numerics;

namespace PrimeGen
{
	public class PrimeSieve : IPrimeSource
	{
		public BigInteger GetPrime(long index)
		{
			if (index < 0) {
				throw new ArgumentOutOfRangeException("index must be positive");
			}

			Init();

			long count = _store.Count;
			//pull last discovered prime
			BigInteger p = _store[count-1] + 2;

			//generate primes if necessary
			while(count <= index)
			{
				bool isPrime = true;
				BigInteger sqr = Sqrt(p);
				int i=0;
				do {
					var check = _store[i];
					BigInteger rem;
					BigInteger.DivRem(p,check, out rem);
					if (rem == 0) {
						isPrime = false;
						break;
					}
					i++;
				} while (i < sqr);

				if (isPrime) {
					_store.Add(p);
					count++;
				}
				p += 2; //skip evens
			}

			return _store[index];
		}

		public BigInteger NextPrime(BigInteger number)
		{
			Init();

			if (number < 2) {
				return 2;
			}

			long index = _store.IndexOf(number);
			if (index > -1) {
				return GetPrime(index + 1);
			}
			//didn't find it so need to produce primes
			index = _store.Count - 1;
			BigInteger p = _store[index];
			while(p <= number) {
				p = GetPrime(++index);
			}
			return p;
		}

		static PrimeStore _store = null;
		static void Init()
		{
			if (_store != null) { return; }
			_store = new PrimeStore("primes.sqlite3");

			if (_store.Count < 8) {
				/*0*/ _store.Add(new BigInteger(2));
				/*1*/ _store.Add(new BigInteger(3));
				/*2*/ _store.Add(new BigInteger(5));
				/*3*/ _store.Add(new BigInteger(7));
				/*4*/ _store.Add(new BigInteger(11));
				/*5*/ _store.Add(new BigInteger(13));
				/*6*/ _store.Add(new BigInteger(17));
				/*7*/ _store.Add(new BigInteger(19));
			};
		}

		static BigInteger Sqrt(BigInteger n)
		{
			if (n == 0) { return 0; }
			if (n <= 0) {
				throw new ArithmeticException("NaN");
			}

			int bitLength = (int)Math.Ceiling(BigInteger.Log(n, 2));
			BigInteger root = BigInteger.One << (bitLength / 2);

			BigInteger last0 = 0;
			BigInteger last1 = 1;
			while(last1 != root)
			{
				last1 = last0;
				last0 = root;
				root = (root + (n / root)) >> 1;
			}

			return BigInteger.Min(root,last0);
		}
	}
}
