namespace PiFormance.Services.CpuRelated
{
	using System.Runtime.Serialization;
	using global::Core.Common.Quantities.Definitions;
	using global::Core.Common.Quantities.TemperatureQuantity;

	[DataContract]
	[KnownType(typeof(Celsius))]
	public class ThermalReading : Temperature
	{
		public ThermalReading(double value, Unit<Temperature> unit) : base(value, unit)
		{	
		}
	}
}