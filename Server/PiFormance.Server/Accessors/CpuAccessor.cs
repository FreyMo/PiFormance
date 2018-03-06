namespace PiFormance.Server.Accessors
{
	using System.Timers;
	using Core.Common.ArgumentMust;
	using Core.Common.Dispose;
	using Core.Common.Extensions;
	using Core.Common.Quantities.FrequencyQuantity;
	using Core.Common.Quantities.FrequencyQuantity.Extensions;
	using Core.Common.Quantities.MemoryQuantity.Extensions;
	using Core.Common.Quantities.RatioQuantity;
	using Core.Common.Quantities.RatioQuantity.Extensions;
	using Hosts;
	using Services.Cpu;
	using Services.CpuRelated;

	public class CpuAccessor : DisposableBase
	{
		private readonly ICpuCallback _cpuCallback;
		private readonly SystemAccess _systemAccess;

		public CpuAccessor(ICpuCallback cpuCallback, SystemAccess systemAccess)
		{
			ArgumentMust.NotBeNull(() => cpuCallback);
			ArgumentMust.NotBeNull(() => systemAccess);

			_cpuCallback = cpuCallback;
			_systemAccess = systemAccess;

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
			var cpu = new Cpu(5.GigaHertz(), new[] {new Core(3, new Temperature(), new Load(50, Percent.Instance))});

			_cpuCallback.CpuChanged(cpu);
			_cpuCallback.RamUsageChanged(new RamUsage(5.GibiBytes(), 200.MebiBytes()));
		}

		protected override void DisposeManagedResources()
		{
			_cpuCallback.As<CpuCallbackProxy>().Dispose();
			_systemAccess.Dispose();
		}
	}
}