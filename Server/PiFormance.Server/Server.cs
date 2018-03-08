namespace PiFormance.Server
{
	using System;
	using System.Threading;
	using Core.Standard.Dispose;
	using HardwareAccess;
	using Hosts;
	using ServiceContracts.SystemService;
	using Services;

	public class Server : DisposableBase
	{
		private readonly SystemProvider _systemProvider;

		public Server()
		{
			var memoryAccess = new MemoryAccess();
			var cpuAccess = new CpuAccess();

			_systemProvider = new SystemProvider(new SystemCallbackProxy(new CpuHost(new SystemService(cpuAccess, memoryAccess))), cpuAccess, memoryAccess);
		}

		protected override void DisposeManagedResources()
		{
			_systemProvider.Dispose();
		}

		public void Run(bool isConsoleVisible)
		{
			if (isConsoleVisible)
			{
				Console.ReadKey();
			}
			else
			{
				while (true)
				{
					Thread.Sleep(100);
				}
			}
		}
	}
}