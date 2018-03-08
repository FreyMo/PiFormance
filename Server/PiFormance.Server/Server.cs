namespace PiFormance.Server
{
	using System;
	using System.Threading;
	using Core.Standard.Dispose;
	using HardwareAccess;
	using Hosts;
	using Services;

	public class Server : DisposableBase
	{
		private readonly SystemHost _systemHost;

		public Server()
		{
			var memoryAccess = new MemoryAccess();
			var cpuAccess = new CpuAccess();

			_systemHost = new SystemHost(new SystemService(cpuAccess, memoryAccess));
		}

		protected override void DisposeManagedResources()
		{
			_systemHost.Dispose();
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