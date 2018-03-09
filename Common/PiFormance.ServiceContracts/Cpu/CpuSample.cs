namespace PiFormance.ServiceContracts.Cpu
{
	using System.Collections.Generic;
	using System.Runtime.Serialization;
	using Core.Standard.ArgumentMust;
	using Core.Standard.Quantities.FrequencyQuantity;

	[DataContract]
	[KnownType(typeof(KiloHertz))]
	[KnownType(typeof(MegaHertz))]
	[KnownType(typeof(GigaHertz))]
	public class CpuSample
	{
		public CpuSample(Frequency clockSpeed, TotalUsage totalUsage, IEnumerable<LogicalCore> cores)
		{
			ArgumentMust.NotBeNull(() => clockSpeed);
			ArgumentMust.NotBeNull(() => totalUsage);
			ArgumentMust.NotBeNullOrEmpty(() => cores);

			ClockSpeed = clockSpeed;
			TotalUsage = totalUsage;
			Cores = cores;
		}

		[DataMember]
		public Frequency ClockSpeed { get; private set; }

		[DataMember]
		public TotalUsage TotalUsage { get; private set; }

		[DataMember]
		public IEnumerable<LogicalCore> Cores { get; private set; }
	}
}