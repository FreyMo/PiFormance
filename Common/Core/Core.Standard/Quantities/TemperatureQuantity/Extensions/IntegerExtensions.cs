namespace Core.Standard.Quantities.TemperatureQuantity.Extensions
{
	using System;

	public static class IntegerExtensions
	{
		public static Temperature DegreesCelsius(this int value)
		{
			return Convert.ToDouble(value).DegreesCelsius();
		}
	}
}