namespace Core.Standard.Quantities.EnergyQuantity.Extensions
{
	using System;

	public static class IntegerExtensions
	{
		public static Energy Joules(this int value)
		{
			return Convert.ToDouble(value).Joules();
		}

		public static Energy MilliJoules(this int value)
		{
			return Convert.ToDouble(value).MilliJoules();
		}
	}
}