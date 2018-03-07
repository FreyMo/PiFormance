namespace PiFormance.Server
{
	using Core.Standard.Dispose;
	using HardwareAccess;
	using Hosts;
	using ServiceContracts.SystemService;

	public class Server : DisposableBase
	{
		private readonly SystemProvider _systemProvider = new SystemProvider(new SystemCallbackProxy(new CpuHost(new SystemService())), new CpuAccess(), new MemoryAccess());

		protected override void DisposeManagedResources()
		{
			_systemProvider.Dispose();
		}
	}
}