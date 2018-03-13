namespace PiFormance.Client.Services.Messengers.Messages
{
	using Core.Standard.ArgumentMust;
	using ServiceContracts.Gpu;

	public class GpuSampleAcquired
	{
		public GpuSampleAcquired(GpuSample gpuSample)
		{
			ArgumentMust.NotBeNull(() => gpuSample);

			GpuSample = gpuSample;
		}

		public GpuSample GpuSample { get; }
	}
}