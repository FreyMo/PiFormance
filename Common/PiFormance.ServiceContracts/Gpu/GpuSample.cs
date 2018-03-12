namespace PiFormance.ServiceContracts.Gpu
{
	using System.Runtime.Serialization;
	using Core.Standard.ArgumentMust;
	using Core.Standard.Quantities.FrequencyQuantity;
	using Core.Standard.Quantities.RatioQuantity;
	using Core.Standard.Quantities.TemperatureQuantity;

	[DataContract]
	[KnownType(typeof(KiloHertz))]
	[KnownType(typeof(MegaHertz))]
	[KnownType(typeof(GigaHertz))]
	[KnownType(typeof(Celsius))]
	[KnownType(typeof(Percent))]
	public class GpuSample
	{
		public GpuSample(string name, GpuClocks gpuClocks, GpuLoads gpuLoads, GpuMemories gpuMemories, Temperature gpuTemperature)
		{
			ArgumentMust.NotBeNullOrWhitespace(() => name);
			ArgumentMust.NotBeNull(() => gpuClocks);
			ArgumentMust.NotBeNull(() => gpuLoads);
			ArgumentMust.NotBeNull(() => gpuMemories);
			ArgumentMust.NotBeNull(() => gpuTemperature);

			Name = name;
			GpuClocks = gpuClocks;
			GpuLoads = gpuLoads;
			GpuMemories = gpuMemories;
			GpuTemperature = gpuTemperature;
		}

		[DataMember]
		public string Name { get; private set; }

		[DataMember]
		public GpuClocks GpuClocks { get; private set; }

		[DataMember]
		public GpuLoads GpuLoads { get; private set; }

		[DataMember]
		public GpuMemories GpuMemories { get; private set; }

		[DataMember]
		public Temperature GpuTemperature { get; private set; }
	}
}