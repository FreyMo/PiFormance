namespace PiFormance.Client.Connection
{
	using System;
	using System.Linq;
	using System.ServiceModel;
	using System.Threading.Tasks;
	using System.Timers;
	using SystemService;
	using ServiceContracts.Cpu;
	using ServiceContracts.Memory;
	using ServiceContracts.SystemService;
	using ISystemService = SystemService.ISystemService;

	public class SystemClient : ClientBase<ISystemService>, ISystemService
	{
		public SystemClient()
		{
			SetupTimer();
		}

		private SystemServiceClient ServiceClient => Client as SystemServiceClient;

		protected override async void SetupServiceClient()
		{
			var addresses = new ConnectionChecker().GetEligableAddresses().ToList();

			foreach (var ipAddress in addresses)
			{
				try
				{
					Client = new SystemServiceClient(new NetTcpBinding(SecurityMode.None), new EndpointAddress("net.tcp://" + ipAddress + ":8733/PiFormance/"));
					Connect();
					await AcknowledgeAsync();
				}
				catch (Exception)
				{
					throw;
				}
			}
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

		protected override void RegisterCallbackHandlers()
		{
			ServiceClient.CpuSampleAcquiredReceived += (x, y) =>
			{
				foreach (var callback in _callbacks)
				{
					callback.CpuSampleAcquired(y.cpuSample);
				}
			};

			ServiceClient.RamSampleAcquiredReceived += (x, y) =>
			{
				foreach (var callback in _callbacks)
				{
					callback.RamSampleAcquired(y.ramSample);
				}
			};
		}
		
		public async Task AcknowledgeAsync()
		{
			await SecureAsyncCall(() => ServiceClient.AcknowledgeAsync());
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