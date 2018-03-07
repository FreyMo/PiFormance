namespace PiFormance.Client.Connection
{
	using System;
	using System.Linq;
	using System.ServiceModel;
	using System.Threading.Tasks;
	using Connected_Services.Cpu;

	public class CpuClient : ClientBase<ICpuService, ICpuServiceCallback>, ICpuClient
	{
		private CpuServiceClient ServiceClient => Client as CpuServiceClient;

		protected override async void SetupServiceClient()
		{
			var addresses = new ConnectionChecker().GetEligableAddresses().ToList();

			foreach (var ipAddress in addresses)
			{
				try
				{
					// Client = new CpuServiceClient(new NetTcpBinding(SecurityMode.None), new EndpointAddress("net.tcp://" + ipAddress + ":8733/PiFormance/"));
					Client = new CpuServiceClient(new NetTcpBinding(SecurityMode.None), new EndpointAddress("net.tcp://192.168.0.241:8733/PiFormance/"));
					Connect();
					await AcknowledgeAsync();
				}
				catch (Exception)
				{
					throw;
				}
			}
		}

		protected override void RegisterCallbackHandlers()
		{
			ServiceClient.CpuChangedReceived += (x, y) =>
			{
				foreach (var callback in _callbacks)
				{
					callback.CpuChanged(y.cpuSample);
				}
			};
		}
		
		public async Task AcknowledgeAsync()
		{
			await SecureAsyncCall(() => ServiceClient.AcknowledgeAsync());
		}
	}
}