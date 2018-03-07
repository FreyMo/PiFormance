namespace PiFormance.Server.Hosts
{
	using System;
	using System.ServiceModel;
	using Core.Standard.ArgumentMust;
	using Core.Standard.Dispose;
	using Core.Standard.Extensions;
	using ServiceContracts.BaseService;

	public abstract class HostBase<TService, TServiceInterface, TCallback> : DisposableBase
		where TService : class, IServiceBase<TCallback>, TServiceInterface
		where TServiceInterface : class
		where TCallback : class
	{
		private readonly ServiceHost _serviceHost;

		protected HostBase(TServiceInterface service)
		{
			ArgumentMust.NotBeNull(() => service);

			Service = service;

			_serviceHost = new ServiceHost(service);
			_serviceHost.Open();
			_serviceHost.Faulted += FaultedEventHandler;
		}

		private void FaultedEventHandler(object sender, EventArgs e)
		{
			Console.WriteLine("Faulted");
		}

		public TServiceInterface Service { get; }

		public TCallback Callback => Service.As<TService>().Callback;
		
		protected override void DisposeManagedResources()
		{
			_serviceHost.Close();
		}
	}
}