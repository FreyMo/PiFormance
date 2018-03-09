namespace PiFormance.ServiceContracts.Cpu
{
	using System.Runtime.Serialization;
	using Core.Standard.Quantities.RatioQuantity;
	using Core.Standard.Quantities.TemperatureQuantity;

	[DataContract]
	[KnownType(typeof(CpuPart))]
	[KnownType(typeof(Percent))]
	[KnownType(typeof(Celsius))]
	public class LogicalCore : CpuPart
	{
		public LogicalCore(int id, Ratio load) : base(load)
		{
			Id = id;
		}

		[DataMember]
		public int Id { get; private set; }
	}
}