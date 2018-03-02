namespace PiFormance.Services.CpuRelated
{
	using System.Collections.Generic;
	using System.Runtime.Serialization;
	using global::Core.Common.ArgumentMust;

	[DataContract]
	public class Cpu
	{
		public Cpu(int id, IEnumerable<Core> cores)
		{
			ArgumentMust.NotBeNullOrEmpty(() => cores);

			Id = id;
			Cores = cores;
		}

		[DataMember]
		public int Id { get; }

		[DataMember]
		public IEnumerable<Core> Cores { get; }
	}
}