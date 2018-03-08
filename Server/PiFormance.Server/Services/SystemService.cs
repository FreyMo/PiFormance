namespace PiFormance.Server.Services
{
	using System;
	using System.ServiceModel;
	using Core.Standard.ArgumentMust;
	using HardwareAccess;
	using ServiceContracts.Cpu;
	using ServiceContracts.Memory;
	using ServiceContracts.SystemService;

	[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
	public class SystemService : ServiceBase, ISystemService
	{
		private readonly ICpuAccess _cpuAccess;
		private readonly IMemoryAccess _memoryAccess;

		public SystemService(ICpuAccess cpuAccess, IMemoryAccess memoryAccess)
		{
			ArgumentMust.NotBeNull(() => cpuAccess);
			ArgumentMust.NotBeNull(() => memoryAccess);

			_cpuAccess = cpuAccess;
			_memoryAccess = memoryAccess;
		}

		public CpuSample GetCpuSample()
		{
			return _cpuAccess.GetCpuSample();
		}

		public RamSample GetRamSample()
		{
			return _memoryAccess.GetRamSample();
		}
	}
}