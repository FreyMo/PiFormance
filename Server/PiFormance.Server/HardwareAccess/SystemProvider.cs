namespace PiFormance.Server.HardwareAccess
{
	using System.Timers;
	using Core.Common.ArgumentMust;
	using Core.Common.Dispose;
	using Core.Common.Extensions;
	using Hosts;
	using Services.Cpu;

	public class SystemProvider : DisposableBase
	{
		private readonly ICpuAccess _cpuAccess;
		private readonly ICpuCallback _cpuCallback;
		private readonly IMemoryAccess _memoryAccess;

		public SystemProvider(ICpuCallback cpuCallback, ICpuAccess cpuAccess, IMemoryAccess memoryAccess)
		{
			ArgumentMust.NotBeNull(() => cpuCallback);
			ArgumentMust.NotBeNull(() => cpuAccess);
			ArgumentMust.NotBeNull(() => memoryAccess);

			_cpuCallback = cpuCallback;
			_cpuAccess = cpuAccess;
			_memoryAccess = memoryAccess;

			SetupTimer();
		}

		private void SetupTimer()
		{
			var timer = new Timer(1000)
			{
				AutoReset = true
			};
			timer.Elapsed += (sender, args) => HandleTimer();
			timer.Start();
		}

		private void HandleTimer()
		{
			_cpuCallback.CpuChanged(_cpuAccess.GetCpuSample());
			_cpuCallback.RamUsageChanged(_memoryAccess.GetRamUsage());
		}

		protected override void DisposeManagedResources()
		{
			_cpuCallback.As<CpuCallbackProxy>().Dispose();
			_cpuAccess.Dispose();
		}
	}
}