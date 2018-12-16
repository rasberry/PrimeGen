using System;
using System.IO;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrimeGen;

namespace test
{
	[TestClass]
	public class DiskBitArrayTest
	{
		[TestMethod]
		public void DBATest1()
		{
			var rnd1 = new Random(555);
			string tmp = Path.GetTempFileName();
			DiskBitArray dba = null;
			try {
				dba = new DiskBitArray(tmp,1024L*1024L);

				for(int b=0; b<dba.Length; b++) {
					bool on = rnd1.Next() % 2 == 1;
					dba[b] = on;
				}

				var rnd2 = new Random(555);
				for(int b=0; b<dba.Length; b++) {
					bool on = rnd2.Next() % 2 == 1;
					bool check = dba[b];
					Assert.AreEqual(on,check);
				}
			}
			finally {
				if (dba != null) {
					dba.Dispose();
				}
				File.Delete(tmp);
			}
		}
	}
}
