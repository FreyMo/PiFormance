namespace PiFormance.ServiceContracts.Memory
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
	public class RamSample
	{
		public RamSample(Memory totalMemory, Memory availableMemory)
		{
			ArgumentMust.NotBeNull(() => totalMemory);
			ArgumentMust.NotBeNull(() => availableMemory);

			TotalMemory = totalMemory;
			AvailableMemory = availableMemory;

			ReservedMemory = (TotalMemory - AvailableMemory).In<GibiByte>();
			 Usage = new Ratio((1.0 - AvailableMemory / TotalMemory) * 100.0, new Percent());
		}

		[DataMember]
		public Memory TotalMemory { get; private set; }

		[DataMember]
		public Memory AvailableMemory { get; private set; }

		[DataMember]
		public Memory ReservedMemory { get; private set; }

		[DataMember]
		public Ratio Usage { get; private set; }
	}
}