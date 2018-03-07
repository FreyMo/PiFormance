namespace PiFormance.Services.CpuRelated
{
	using System.Collections.Generic;
	using System.Runtime.Serialization;

	[DataContract]
	public class CpuSample
	{
		public CpuSample(Frequency clockSpeed, IEnumerable<Core> cores)
		{
			ArgumentMust.NotBeNull(() => clockSpeed);
			ArgumentMust.NotBeNullOrEmpty(() => cores);

			ClockSpeed = clockSpeed;
			Cores = cores;
		}
		
		[DataMember]
		public Frequency ClockSpeed { get; private set; }

		[DataMember]
		public IEnumerable<Core> Cores { get; private set; }
	}
}