namespace Core.Standard.Quantities.TemperatureQuantity
{
	using System;
	using Definitions;

	[Serializable]
	public class Temperature : PhysicalQuantity<Temperature>
	{
		public Temperature() : this(default(double))
		{
		}

		public Temperature(double value) : base(value, Celsius.Instance)
		{
		}

		public Temperature(double value, Unit<Temperature> unit) : base(value, unit)
		{
		}

		public override BaseUnit<Temperature> BaseUnit => Celsius.Instance;
	}
}