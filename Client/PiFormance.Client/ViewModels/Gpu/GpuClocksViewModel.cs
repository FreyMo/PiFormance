namespace PiFormance.Client.ViewModels.Gpu
{
	using Base;
	using Core.Standard.ArgumentMust;
	using Core.Standard.Messenger.Messenger;
	using Core.Standard.Quantities.FrequencyQuantity;
	using Services.Messengers;
	using Services.Messengers.Messages;

	public class GpuClocksViewModel : ViewModel, ISubscriberTo<GpuSampleAcquired>
	{
		public GpuClocksViewModel(SampleMessenger messenger)
		{
			ArgumentMust.NotBeNull(() => messenger);

			messenger.SubscribeTo(this);
		}

		public void OnMessageReceived(GpuSampleAcquired message)
		{
			ArgumentMust.NotBeNull(() => message);

			CoreClock.Value = message.GpuSample.GpuClocks.CoreClock.In<GigaHertz>().Value;
			MemoryClock.Value = message.GpuSample.GpuClocks.MemoryClock.In<GigaHertz>().Value;
			ShaderClock.Value = message.GpuSample.GpuClocks.ShaderClock.In<GigaHertz>().Value;
		}

		public Frequency CoreClock { get; } = new Frequency(0, GigaHertz.Instance);

		public Frequency MemoryClock { get; } = new Frequency(0, GigaHertz.Instance);

		public Frequency ShaderClock { get; } = new Frequency(0, GigaHertz.Instance);
	}
}