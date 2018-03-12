namespace PiFormance.ServiceContracts.Gpu
{
	using System.Runtime.Serialization;
	using Core.Standard.ArgumentMust;
	using Core.Standard.Quantities.MemoryQuantity;
	using Core.Standard.Quantities.RatioQuantity;

	[DataContract]
	[KnownType(typeof(KibiByte))]
	[KnownType(typeof(MebiByte))]
	[KnownType(typeof(GibiByte))]
	[KnownType(typeof(Percent))]
	public class GpuMemories
	{
		public GpuMemories(Memory availableMemory, Memory usedMemory, Memory totalMemory)
		{
			ArgumentMust.NotBeNull(() => availableMemory);
			ArgumentMust.NotBeNull(() => usedMemory);
			ArgumentMust.NotBeNull(() => totalMemory);

			AvailableMemory = availableMemory;
			UsedMemory = usedMemory;
			TotalMemory = totalMemory;

			MemoryUsage = new Ratio((1.0 - AvailableMemory / TotalMemory) * 100.0, new Percent());
		}

		[DataMember]
		public Memory AvailableMemory { get; private set; }

		[DataMember]
		public Memory UsedMemory { get; private set; }

		[DataMember]
		public Memory TotalMemory { get; private set; }

		[DataMember]
		public Ratio MemoryUsage { get; private set; }
	}
}