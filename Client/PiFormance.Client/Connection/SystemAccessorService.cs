namespace PiFormance.Client.Connection
{
	using ServiceContracts.Cpu;
	using ServiceContracts.Memory;
	using ServiceContracts.SystemService;

	public class SystemAccessorService : ISystemCallback
	{
		public void CpuSampleAcquired(CpuSample cpuSample)
		{
		}

		public void RamSampleAcquired(RamSample ramSample)
		{
		}
	}
}