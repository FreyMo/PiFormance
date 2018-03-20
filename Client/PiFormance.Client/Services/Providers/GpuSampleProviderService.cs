namespace PiFormance.Client.Services.Providers
{
	using Client.Connection;
	using Core.Standard.ArgumentMust;
	using Core.Standard.Messenger.Messenger;
	using Messengers;
	using Messengers.Messages;

	public class GpuSampleProviderService : SampleProviderService, ISubscriberTo<SamplesShouldBeAcquired>
	{
		public GpuSampleProviderService(SampleMessenger messenger, SystemClient systemClient) : base(messenger, systemClient)
		{
			Messenger.SubscribeTo(this);
		}

		public async void OnMessageReceived(SamplesShouldBeAcquired message)
		{
			ArgumentMust.NotBeNull(() => message);

			var sample = await Client.GetGpuSampleAsync();
			Messenger.Post(new GpuSampleAcquired(sample));
		}
	}
}