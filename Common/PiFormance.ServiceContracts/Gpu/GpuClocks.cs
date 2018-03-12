namespace PiFormance.ServiceContracts.Gpu
{
	using System.Runtime.Serialization;
	using Core.Standard.ArgumentMust;
	using Core.Standard.Quantities.FrequencyQuantity;

	[DataContract]
	[KnownType(typeof(KiloHertz))]
	[KnownType(typeof(MegaHertz))]
	[KnownType(typeof(GigaHertz))]
	public class GpuClocks
	{
		public GpuClocks(Frequency coreClock, Frequency memoryClock, Frequency shaderClock)
		{
			ArgumentMust.NotBeNull(() => coreClock);
			ArgumentMust.NotBeNull(() => memoryClock);
			ArgumentMust.NotBeNull(() => shaderClock);

			CoreClock = coreClock;
			MemoryClock = memoryClock;
			ShaderClock = shaderClock;
		}

		[DataMember]
		public Frequency CoreClock { get; private set; }

		[DataMember]
		public Frequency MemoryClock { get; private set; }

		[DataMember]
		public Frequency ShaderClock { get; private set; }
	}
}