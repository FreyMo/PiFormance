namespace PiFormance.Server
{
	using Core.Common.Dispose;
	using HardwareAccess;
	using Hosts;
	using Services.Cpu;

	public class Server : DisposableBase
	{
		private readonly SystemProvider _systemProvider = new SystemProvider(new CpuCallbackProxy(new CpuHost(new CpuService())), new CpuAccess(), new MemoryAccess());

		protected override void DisposeManagedResources()
		{
			_systemProvider.Dispose();
		}
	}
}