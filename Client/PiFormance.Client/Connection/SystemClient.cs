namespace PiFormance.Client.Connection
{
	using System;
	using System.Linq;
	using System.ServiceModel;
	using System.Threading.Tasks;
	using System.Timers;
	using ServiceContracts.Cpu;
	using ServiceContracts.Memory;
	using Services;

	public class SystemClient : BaseClient<ISystemService>, ISystemService
	{
		public SystemClient()
		{
			SetupTimer();
		}

		private SystemServiceClient ServiceClient => Client as SystemServiceClient;

		protected override void SetupServiceClient()
		{
			var ipAddress = new ConnectionChecker().GetServerAddress();

			Client = new SystemServiceClient(new NetTcpBinding(SecurityMode.None), new EndpointAddress("net.tcp://" + ipAddress + ":8733/PiFormance/"));
			Connect();
		}

		protected override void RegisterCallbackHandlers()
		{
		}

		private void SetupTimer()
		{
			var timer = new Timer(1000)
			{
				AutoReset = true
			};
			timer.Elapsed += (sender, args) => HandleTimer();
			timer.Start();
		}

		private async void HandleTimer()
		{
			var cpuSample = await GetCpuSampleAsync();
			var ramSample = await GetRamSampleAsync();
		}
		
		public async Task<CpuSample> GetCpuSampleAsync()
		{
			return await SecureAsyncCall(() => ServiceClient.GetCpuSampleAsync());
		}

		public async Task<RamSample> GetRamSampleAsync()
		{
			return await SecureAsyncCall(() => ServiceClient.GetRamSampleAsync());
		}
	}
}