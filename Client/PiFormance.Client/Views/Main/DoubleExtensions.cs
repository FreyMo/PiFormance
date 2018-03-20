namespace PiFormance.Client.Views.Main
{
	public static class DoubleExtensions
	{
		public static double Inbetween(this double value, ushort lowerLimit, ushort upperLimit)
		{
			if (value <= lowerLimit)
			{
				return lowerLimit;
			}

			if (value >= upperLimit)
			{
				return upperLimit;
			}

			return value;
		}
	}
}