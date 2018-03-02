namespace PiFormance.Client.Connection
{
	using System.ServiceModel;
	using System.Threading.Tasks;
	using Cpu;

	public class CpuClient : ClientBase<ICpuService, ICpuServiceCallback>, ICpuClient
	{
		private CpuServiceClient ServiceClient => Client as CpuServiceClient;

		protected override async void SetupServiceClient()
		{
			Client = new CpuServiceClient(new NetTcpBinding(SecurityMode.None), new EndpointAddress("net.tcp://localhost:8733/PiFormance/"));
			Connect();
			await AcknowledgeAsync();
		}

		protected override void RegisterCallbackHandlers()
		{
			ServiceClient.CpuChangedReceived += (x, y) =>
			{
				foreach (var callback in _callbacks)
				{
					callback.CpuChanged(y.cpu);
				}
			};
		}
		
		public async Task AcknowledgeAsync()
		{
			await SecureAsyncCall(() => ServiceClient.AcknowledgeAsync());
		}
	}
}