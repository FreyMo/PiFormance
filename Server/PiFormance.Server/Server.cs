namespace PiFormance.Server
{
	using Accessors;
	using Core.Common.Dispose;
	using Hosts;
	using Services.Cpu;

	public class Server : DisposableBase
	{
		private readonly CpuAccessor _cpuAccessor = new CpuAccessor(new CpuCallbackProxy(new CpuHost(new CpuService())));

		protected override void DisposeManagedResources()
		{
			_cpuAccessor.Dispose();
		}

		protected override void DisposeUnmanagedResources()
		{
		}
	}
}