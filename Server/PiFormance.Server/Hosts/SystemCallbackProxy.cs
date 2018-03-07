namespace PiFormance.Server.Hosts
{
	using System;
	using Core.Standard.ArgumentMust;
	using Core.Standard.Dispose;
	using ServiceContracts.Cpu;
	using ServiceContracts.Memory;
	using ServiceContracts.SystemService;

	public class SystemCallbackProxy : DisposableBase, ISystemCallback
	{
		private readonly CpuHost _host;

		public SystemCallbackProxy(CpuHost host)
		{
			ArgumentMust.NotBeNull(() => host);

			_host = host;
		}

		protected override void DisposeManagedResources()
		{
			_host.Dispose();
		}

		public void CpuSampleAcquired(CpuSample cpuSample)
		{
			if (_host.Callback != null)
			{
				_host.Callback.CpuSampleAcquired(cpuSample);
				Console.WriteLine("CALLBACK SENT!");
			}
			else
			{
				Console.WriteLine("Callback sent to no one.");
			}
		}

		public void RamSampleAcquired(RamSample ramSample)
		{
			if (_host.Callback != null)
			{
				_host.Callback.RamSampleAcquired(ramSample);
				Console.WriteLine("CALLBACK SENT!");
			}
			else
			{
				Console.WriteLine("Callback sent to no one.");
			}
		}
	}
}