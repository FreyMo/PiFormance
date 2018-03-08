namespace Core.Standard.Extensions
{
	using System;

	public static class DoubleExtensions
	{
		public static float ToSingle(this double d)
		{
			return Convert.ToSingle(d);
		}

		public static bool IsEqualTo(this double source, double target)
		{
			return Math.Abs(source - target) < 1e-6;
		}
	}
}