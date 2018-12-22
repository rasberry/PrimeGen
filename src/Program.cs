using System;
using System.Diagnostics;
using System.IO;
using System.Numerics;

namespace PrimeGen
{
	class Program
	{
		static void Main(string[] args)
		{
			if (args.Length < 1) {
				Log.Message("Use -h / --help to show full help");
				return;
			}
			if (!Options.ParseArgs(args) || !Options.AreInputsSane()) {
				return;
			}

			try {
				MainMain();
			}
			catch(Exception e) {
				#if DEBUG
				Log.Error(e.ToString());
				#else
				Log.Error(e.Message);
				#endif
			}
		}

		static void MainMain()
		{
			Log.Debug("a = "+Options.Action);

			switch(Options.Action)
			{
			case Options.ActionType.Gen: DoGen(); break;
			case Options.ActionType.Bits: DoBits(); break;
			case Options.ActionType.BitsImg: DoBitsImg(); break;
			}
		}

		static void DoGen()
		{
			IPrimeSource gen = null;
			switch(Options.WhichGen)
			{
			case Options.GenType.Division:
				gen = new GenDivision();
				break;
			case Options.GenType.Pascal:
				gen = new GenPascal();
				break;
			}

			TextWriter tw = null;
			try {
				if (Options.OutputFile != null) {
					var fs = File.Open(Options.OutputFile,FileMode.Create,FileAccess.Write,FileShare.Read);
					tw = new StreamWriter(fs);
				} else {
					tw = Console.Out;
				}

				BigInteger p = Options.Start - 1;
				Log.Debug("s = "+p);
				while(p <= Options.End) {
					p = gen.NextPrime(p);
					tw.WriteLine(p);
				}
			}
			finally {
				if (Options.OutputFile != null && tw != null) {
					tw.Dispose();
				}
			}
		}

		static void DoBits()
		{
			var bits = new BitsEratosthenes();
			bits.FillPrimes(0);
		}

		static void DoBitsImg()
		{
		}
	}
}
