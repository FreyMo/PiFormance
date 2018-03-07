namespace PiFormance.ServiceContracts.Memory
{
	using System.Runtime.Serialization;
	using Core.Standard.ArgumentMust;
	using Core.Standard.Quantities.MemoryQuantity;
	using Core.Standard.Quantities.RatioQuantity;

	[DataContract]
	public class RamSample
	{
		public RamSample(Memory totalMemory, Memory availableMemory)
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