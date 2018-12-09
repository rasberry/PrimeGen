using System;

namespace PrimeGen
{
	public static class Helpers
	{
		public static bool EndsWithIC(this string subj,string check)
		{
			if (subj == null) { return false; }
			return subj.EndsWith(check,StringComparison.OrdinalIgnoreCase);
		}
	}

	public struct SizeL
	{
		public SizeL(long w,long h) {
			Width = w;
			Height = h;
		}
		public long Width;
		public long Height;
	}
}