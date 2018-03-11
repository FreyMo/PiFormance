namespace PiFormance.Client.Connection
{
	using System.ServiceModel;
	using System.Threading.Tasks;
	using Connected_Services.Services;
	using ServiceContracts.Cpu;
	using ServiceContracts.Memory;

	public class SystemClient : BaseClient<ISystemService>, ISystemService
	{
		private SystemServiceClient ServiceClient => Client as SystemServiceClient;

		public async Task<CpuSample> GetCpuSampleAsync()
		{
			return await SecureAsyncCall(() => ServiceClient.GetCpuSampleAsync());
		}

		public async Task<RamSample> GetRamSampleAsync()
		{
			return await SecureAsyncCall(() => ServiceClient.GetRamSampleAsync());
		}

		protected override void SetupServiceClient()
		{
			var ipAddress = new ConnectionChecker().GetServerAddress();

			Client = new SystemServiceClient(
				new NetTcpBinding(SecurityMode.None),
				new EndpointAddress("net.tcp://" + ipAddress + ":8733/PiFormance/"));
			Connect();
		}

		protected override void RegisterCallbackHandlers()
		{
		}
	}
}