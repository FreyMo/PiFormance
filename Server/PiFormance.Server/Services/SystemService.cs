namespace PiFormance.Server.Services
{
	using System;
	using System.ServiceModel;
	using Core.Standard.ArgumentMust;
	using HardwareAccess;
	using ServiceContracts.Cpu;
	using ServiceContracts.Gpu;
	using ServiceContracts.Memory;
	using ServiceContracts.SystemService;

	[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
	public class SystemService : ServiceBase, ISystemService
	{
		private readonly ICpuAccess _cpuAccess;
		private readonly IMemoryAccess _memoryAccess;
		private readonly IGpuAccess _gpuAccess;

		public SystemService(ICpuAccess cpuAccess, IMemoryAccess memoryAccess, IGpuAccess gpuAccess)
		{
			ArgumentMust.NotBeNull(() => cpuAccess);
			ArgumentMust.NotBeNull(() => memoryAccess);
			ArgumentMust.NotBeNull(() => gpuAccess);

			_cpuAccess = cpuAccess;
			_memoryAccess = memoryAccess;
			_gpuAccess = gpuAccess;
		}

		public CpuSample GetCpuSample()
		{
			return _cpuAccess.GetCpuSample();
		}

		public RamSample GetRamSample()
		{
			return _memoryAccess.GetRamSample();
		}

		public GpuSample GetGpuSample()
		{
			return _gpuAccess.GetGpuSample();
		}
	}
}