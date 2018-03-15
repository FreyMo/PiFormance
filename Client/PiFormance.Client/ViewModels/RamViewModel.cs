namespace PiFormance.Client.ViewModels
{
	using Base;
	using Core.Standard.ArgumentMust;
	using Core.Standard.Messenger.Messenger;
	using Core.Standard.Quantities.MemoryQuantity;
	using Core.Standard.Quantities.RatioQuantity;
	using Services.Messengers;
	using Services.Messengers.Messages;
	using Services.Providers;

	public class RamViewModel : ViewModel, ISubscriberTo<RamSampleAcquired>
	{
		public RamViewModel(SampleMessenger messenger, RamSampleProviderService ramSampleProviderService)
		{
			ArgumentMust.NotBeNull(() => messenger);
			ArgumentMust.NotBeNull(() => messenger);

			messenger.SubscribeTo(this);
		}
		
		public Memory AvailableMemory { get; } = new Memory(0, GibiByte.Instance);

		public Memory ReservedMemory { get; } = new Memory(0, GibiByte.Instance);

		public Memory TotalMemory { get; } = new Memory(0, GibiByte.Instance);

		public Ratio Usage { get; } = new Ratio(0, Percent.Instance);

		public void OnMessageReceived(RamSampleAcquired message)
		{
			ArgumentMust.NotBeNull(() => message);

			AvailableMemory.Value = message.RamSample.AvailableMemory.In<GibiByte>().Value;
			ReservedMemory.Value = message.RamSample.ReservedMemory.In<GibiByte>().Value;
			TotalMemory.Value = message.RamSample.TotalMemory.In<GibiByte>().Value;
			Usage.Value = message.RamSample.Usage.In<Percent>().Value;
		}
	}
}