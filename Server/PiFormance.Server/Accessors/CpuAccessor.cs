namespace PiFormance.Server.Accessors
{
	using System.Timers;
	using Core.Common.ArgumentMust;
	using Core.Common.Dispose;
	using Core.Common.Extensions;
	using Hosts;
	using Services.Cpu;
	using Services.CpuRelated;

	public class CpuAccessor : DisposableBase
	{
		private readonly ICpuCallback _cpuCallback;

		public CpuAccessor(ICpuCallback cpuCallback)
		{
			ArgumentMust.NotBeNull(() => cpuCallback);

			_cpuCallback = cpuCallback;

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
			var cpu = new Cpu(5, new[] {new Core(3, new Clock(), new Temperature(), new Load())});

			_cpuCallback.CpuChanged(cpu);
		}

		protected override void DisposeManagedResources()
		{
			_cpuCallback.As<CpuCallbackProxy>().Dispose();
		}

		protected override void DisposeUnmanagedResources()
		{
		}
	}
}