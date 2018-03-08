namespace PiFormance.Server.HardwareAccess
{
	using System.Timers;
	using Core.Standard.ArgumentMust;
	using Core.Standard.Dispose;
	using Core.Standard.Extensions;
	using Hosts;
	using ServiceContracts.SystemService;

	public class SystemProvider : DisposableBase
	{
		private readonly ICpuAccess _cpuAccess;
		private readonly ISystemCallback _systemCallback;
		private readonly IMemoryAccess _memoryAccess;

		public SystemProvider(ISystemCallback systemCallback, ICpuAccess cpuAccess, IMemoryAccess memoryAccess)
		{
			ArgumentMust.NotBeNull(() => systemCallback);
			ArgumentMust.NotBeNull(() => cpuAccess);
			ArgumentMust.NotBeNull(() => memoryAccess);

			_systemCallback = systemCallback;
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
			_systemCallback.CpuSampleAcquired(_cpuAccess.GetCpuSample());
			_systemCallback.RamSampleAcquired(_memoryAccess.GetRamSample());
		}

		protected override void DisposeManagedResources()
		{
			_systemCallback.As<SystemCallbackProxy>().Dispose();
			_cpuAccess.Dispose();
		}
	}
}