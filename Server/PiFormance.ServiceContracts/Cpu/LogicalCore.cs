namespace PiFormance.ServiceContracts.Cpu
{
	using System.Runtime.Serialization;
	using Core.Standard.ArgumentMust;
	using Core.Standard.Quantities.RatioQuantity;
	using Core.Standard.Quantities.TemperatureQuantity;

	[DataContract]
	[KnownType(typeof(Percent))]
	[KnownType(typeof(Celsius))]
	public class LogicalCore
	{
		public LogicalCore(int id, Temperature temperature, Ratio load)
		{
			ArgumentMust.NotBeNull(() => temperature);
			ArgumentMust.NotBeNull(() => load);

			Id = id;
			Temperature = temperature;
			Load = load;
		}

		[DataMember]
		public int Id { get; private set; }

		[DataMember]
		public Temperature Temperature { get; private set; }

		[DataMember]
		public Ratio Load { get; private set; }
	}
}