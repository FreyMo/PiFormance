namespace PiFormance.Server.Hosts
{
	using System;
	using Core.Standard.ArgumentMust;
	using Core.Standard.Dispose;
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

		public void CpuChanged(CpuSample cpuSample)
		{
			if (_host.Callback != null)
			{
				_host.Callback.CpuChanged(cpuSample);
				Console.WriteLine("CALLBACK SENT!");
			}
			else
			{
				Console.WriteLine("Callback sent to no one.");
			}
		}

		public void RamUsageChanged(RamSample ramSample)
		{
			if (_host.Callback != null)
			{
				_host.Callback.RamUsageChanged(ramSample);
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
	}
}