namespace PiFormance.Client.Services.Providers
{
	using Connection;
	using Core.Standard.ArgumentMust;
	using Core.Standard.Messenger.Messenger;
	using Messengers;
	using Messengers.Messages;

	public class RamSampleProviderService : SampleProviderService, ISubscriberTo<SamplesShouldBeAcquired>
	{
		public RamSampleProviderService(SampleMessenger messenger, SystemClient systemClient) : base(messenger, systemClient)
		{
			Messenger.SubscribeTo(this);
		}

		public async void OnMessageReceived(SamplesShouldBeAcquired message)
		{
			ArgumentMust.NotBeNull(() => message);

			var sample = await Client.GetRamSampleAsync();
			Messenger.Post(new RamSampleAcquired(sample));
		}
	}
}