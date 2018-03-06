namespace PiFormance.Services.CpuRelated
{
	using System.Runtime.Serialization;
	using global::Core.Common.ArgumentMust;
	using global::Core.Common.Quantities.MemoryQuantity;
	using global::Core.Common.Quantities.RatioQuantity;

	[DataContract]
	public class RamUsage
	{
		public RamUsage(Memory totalMemory, Memory availableMemory)
		{
			ArgumentMust.NotBeNull(() => totalMemory);
			ArgumentMust.NotBeNull(() => availableMemory);

			TotalMemory = totalMemory;
			AvailableMemory = availableMemory;
		}

		[DataMember]
		public Memory TotalMemory { get; }

		[DataMember]
		public Memory AvailableMemory { get; }

		[DataMember]
		public Ratio Usage => new Ratio((1.0 - AvailableMemory / TotalMemory) * 100.0, new Percent());
	}
}