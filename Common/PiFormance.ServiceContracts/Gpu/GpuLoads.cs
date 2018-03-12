namespace PiFormance.ServiceContracts.Gpu
{
	using System.Runtime.Serialization;
	using Core.Standard.ArgumentMust;
	using Core.Standard.Quantities.RatioQuantity;

	[DataContract]
	[KnownType(typeof(Percent))]
	public class GpuLoads
	{
		public GpuLoads(Ratio coreLoad, Ratio memoryControllerLoad, Ratio videoEngineLoad)
		{
			ArgumentMust.NotBeNull(() => coreLoad);
			ArgumentMust.NotBeNull(() => memoryControllerLoad);
			ArgumentMust.NotBeNull(() => videoEngineLoad);

			CoreLoad = coreLoad;
			MemoryControllerLoad = memoryControllerLoad;
			VideoEngineLoad = videoEngineLoad;
		}

		[DataMember]
		public Ratio CoreLoad { get; private set; }

		[DataMember]
		public Ratio MemoryControllerLoad { get; private set; }

		[DataMember]
		public Ratio VideoEngineLoad { get; private set; }
	}
}