namespace PiFormance.Client.Services.Cpu
{
	using Connection;
	using Core.Standard.ArgumentMust;
	using Messengers;

	public abstract class SampleProviderService
	{
		protected SampleProviderService(CpuSampleMessenger messenger, SystemClient systemClient)
		{
			ArgumentMust.NotBeNull(() => messenger);
			ArgumentMust.NotBeNull(() => systemClient);

			Messenger = messenger;
			Client = systemClient;
		}

		protected SystemClient Client { get; }

		protected CpuSampleMessenger Messenger { get; }
	}
}