namespace PiFormance.Client.Services.Messengers.Messages
{
	using Core.Standard.ArgumentMust;
	using ServiceContracts.Cpu;

	public class CpuSampleAcquired
	{
		public CpuSampleAcquired(CpuSample cpuSample)
		{
			ArgumentMust.NotBeNull(() => cpuSample);

			CpuSample = cpuSample;
		}

		public CpuSample CpuSample { get; }
	}
}