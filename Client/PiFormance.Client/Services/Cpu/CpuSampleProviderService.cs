namespace PiFormance.Client.Services.Cpu
{
	using Connection;
	using Core.Standard.ArgumentMust;
	using Core.Standard.Messenger.Messenger;
	using Messengers;
	using Messengers.Messages;

	public class CpuSampleProviderService : ISubscriberTo<CpuSampleShouldBeAcquired>, ISubscriberTo<RamSampleShouldBeAcquired>
	{
		private readonly SystemClient _client;
		private readonly CpuSampleMessenger _cpuSampleMessenger;

		public CpuSampleProviderService(CpuSampleMessenger cpuSampleMessenger)
		{
			ArgumentMust.NotBeNull(() => cpuSampleMessenger);

			// TODO: RELOCATE
			_client = new SystemClient();

			_cpuSampleMessenger = cpuSampleMessenger;
			_cpuSampleMessenger.SubscribeTo<CpuSampleShouldBeAcquired>(this);
			_cpuSampleMessenger.SubscribeTo<RamSampleShouldBeAcquired>(this);
		}

		public async void OnMessageReceived(CpuSampleShouldBeAcquired message)
		{
			var sample = await _client.GetCpuSampleAsync();
			_cpuSampleMessenger.Post(new CpuSampleAcquired(sample));
		}

		public async void OnMessageReceived(RamSampleShouldBeAcquired message)
		{
			var sample = await _client.GetRamSampleAsync();
			_cpuSampleMessenger.Post(new RamSampleAcquired(sample));
		}
	}
}