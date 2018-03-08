namespace PiFormance.Client.Connection
{
	using System;
	using System.Linq;
	using System.ServiceModel;
	using System.Threading.Tasks;
	using SystemService;
	using ServiceContracts.SystemService;
	using ISystemService = SystemService.ISystemService;

	public class SystemClient : ClientBase<ISystemService, ISystemCallback>, ISystemService
	{
		private SystemServiceClient ServiceClient => Client as SystemServiceClient;

		protected override async void SetupServiceClient()
		{
			var addresses = new ConnectionChecker().GetEligableAddresses().ToList();

			foreach (var ipAddress in addresses)
			{
				try
				{
					// Client = new SystemServiceClient(new NetTcpBinding(SecurityMode.None), new EndpointAddress("net.tcp://" + ipAddress + ":8733/PiFormance/"));
					Client = new SystemServiceClient(new NetTcpBinding(SecurityMode.None), new EndpointAddress("net.tcp://192.168.0.241:8733/PiFormance/"));
					Connect();
					await AcknowledgeAsync(new Acknowledge());
				}
				catch (Exception)
				{
					throw;
				}
			}
		}

		protected override void RegisterCallbackHandlers()
		{
			ServiceClient.CpuSampleAcquiredReceived += (x, y) =>
			{
				foreach (var callback in _callbacks)
				{
					callback.CpuSampleAcquired(y.request.cpuSample);
				}
			};

			ServiceClient.RamSampleAcquiredReceived += (x, y) =>
			{
				foreach (var callback in _callbacks)
				{
					callback.RamSampleAcquired(y.request.ramSample);
				}
			};
		}
		
		public async Task AcknowledgeAsync(Acknowledge request)
		{
			await SecureAsyncCall(() => ServiceClient.AcknowledgeAsync(request));
		}
	}
}