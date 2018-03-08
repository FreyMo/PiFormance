namespace Core.Standard.Quantities.TemperatureQuantity
{
	using System;
	using Definitions;

	[Serializable]
	public class Celsius : BaseUnit<Temperature>
	{
		public static Celsius Instance { get; } = new Celsius();

		public override string Symbol => "°C";
	}
}