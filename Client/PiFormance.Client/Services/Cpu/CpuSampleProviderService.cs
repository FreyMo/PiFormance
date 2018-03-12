namespace PiFormance.Client.Services.Cpu
{
	using Connection;
	using Core.Standard.ArgumentMust;
	using Core.Standard.Messenger.Messenger;
	using Messengers;
	using Messengers.Messages;

	public class CpuSampleProviderService : SampleProviderService, ISubscriberTo<CpuSampleShouldBeAcquired>
	{
		public CpuSampleProviderService(CpuSampleMessenger messenger, SystemClient systemClient) : base(messenger, systemClient)
		{
			Messenger.SubscribeTo(this);
		}

		public async void OnMessageReceived(CpuSampleShouldBeAcquired message)
		{
			ArgumentMust.NotBeNull(() => message);

			var sample = await Client.GetCpuSampleAsync();
			Messenger.Post(new CpuSampleAcquired(sample));
		}
	}
}