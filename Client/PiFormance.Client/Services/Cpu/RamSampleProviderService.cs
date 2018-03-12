namespace PiFormance.Client.Services.Cpu
{
	using Connection;
	using Core.Standard.ArgumentMust;
	using Core.Standard.Messenger.Messenger;
	using Messengers;
	using Messengers.Messages;

	public class RamSampleProviderService : SampleProviderService, ISubscriberTo<RamSampleShouldBeAcquired>
	{
		public RamSampleProviderService(CpuSampleMessenger messenger, SystemClient systemClient) : base(messenger, systemClient)
		{
			Messenger.SubscribeTo(this);
		}

		public async void OnMessageReceived(RamSampleShouldBeAcquired message)
		{
			ArgumentMust.NotBeNull(() => message);

			var sample = await Client.GetRamSampleAsync();
			Messenger.Post(new RamSampleAcquired(sample));
		}
	}
}