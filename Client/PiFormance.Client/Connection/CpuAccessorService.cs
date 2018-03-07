namespace PiFormance.Client.Connection
{
	using Connected_Services.Cpu;

	public class CpuAccessorService : ICpuServiceCallback
	{
		public void CpuChanged(CpuSample cpuSample)
		{
		}

		public void RamUsageChanged(RamSample ramSample)
		{
		}
	}
}