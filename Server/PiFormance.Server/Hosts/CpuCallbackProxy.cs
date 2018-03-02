namespace PiFormance.Server.Hosts
{
	using System;
	using Core.Common.ArgumentMust;
	using Core.Common.Dispose;
	using Services.Cpu;
	using Services.CpuRelated;

	public class CpuCallbackProxy : DisposableBase, ICpuCallback
	{
		private readonly CpuHost _host;

		public CpuCallbackProxy(CpuHost host)
		{
			ArgumentMust.NotBeNull(() => host);

			_host = host;
		}

		public void CpuChanged(Cpu cpu)
		{
			if (_host.Callback != null)
			{
				_host.Callback.CpuChanged(cpu);
				Console.WriteLine("CALLBACK SENT!");
			}
			else
			{
				Console.WriteLine("Callback sent to no one.");
			}
		}

		protected override void DisposeManagedResources()
		{
			_host.Dispose();
		}

		protected override void DisposeUnmanagedResources()
		{
		}
	}
}