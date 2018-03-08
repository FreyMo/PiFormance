namespace PiFormance.Server
{
	using System;
	using System.Threading;
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