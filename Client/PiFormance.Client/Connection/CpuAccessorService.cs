namespace PiFormance.Client.Connection
{
	using Cpu;

	public class CpuAccessorService : ICpuServiceCallback
	{
		public void CpuChanged(CpuSample cpuSample)
		{
		}

		public void RamUsageChanged(RamUsage ramUsage)
		{
		}
	}
}