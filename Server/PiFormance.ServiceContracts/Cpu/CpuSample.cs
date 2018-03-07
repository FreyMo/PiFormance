namespace PiFormance.ServiceContracts.Cpu
{
	using System.Collections.Generic;
	using System.Runtime.Serialization;
	using Core.Standard.ArgumentMust;
	using Core.Standard.Quantities.FrequencyQuantity;

	[DataContract]
	public class CpuSample
	{
		public CpuSample(Frequency clockSpeed, IEnumerable<LogicalCore> cores)
		{
			ArgumentMust.NotBeNull(() => clockSpeed);
			ArgumentMust.NotBeNullOrEmpty(() => cores);

			ClockSpeed = clockSpeed;
			Cores = cores;
		}

		[DataMember]
		public Frequency ClockSpeed { get; private set; }

		[DataMember]
		public IEnumerable<LogicalCore> Cores { get; private set; }
	}
}