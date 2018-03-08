namespace PiFormance.Server.Hosts
{
	using System;
	using System.ServiceModel;
	using Core.Standard.ArgumentMust;
	using Core.Standard.Dispose;
	using ServiceContracts.BaseService;

	public abstract class HostBase<TService> : DisposableBase
		where TService : class, IServiceBase
	{
		private readonly ServiceHost _serviceHost;

		protected HostBase(TService service)
		{
			ArgumentMust.NotBeNull(() => service);
			
			_serviceHost = new ServiceHost(service);

			_serviceHost.Faulted += FaultedEventHandler;
			_serviceHost.Closing += ClosingEventHandler;
			_serviceHost.Closed += ClosedEventHandler;

			_serviceHost.Open();
		}

		private void ClosedEventHandler(object sender, EventArgs e)
		{
			Console.WriteLine("Closed");
		}

		private void ClosingEventHandler(object sender, EventArgs e)
		{
			Console.WriteLine("Closing");
		}

		private void FaultedEventHandler(object sender, EventArgs e)
		{
			Console.WriteLine("Faulted");
		}

		protected override void DisposeManagedResources()
		{
			_serviceHost.Close();
		}
	}
}