namespace PiFormance.Client.ViewModels.Gpu
{
	using Base;
	using Core.Standard.ArgumentMust;
	using Core.Standard.Messenger.Messenger;
	using Core.Standard.Quantities.FrequencyQuantity;
	using Core.Standard.Quantities.RatioQuantity;
	using Core.Standard.Quantities.TemperatureQuantity;
	using Services.Cpu;
	using Services.Messengers;
	using Services.Messengers.Messages;

	public class GpuViewModel : ViewModel, ISubscriberTo<GpuSampleAcquired>
	{
		public GpuViewModel(SampleMessenger messenger, GpuSampleProviderService sampleProviderService)
		{
			ArgumentMust.NotBeNull(() => messenger);

			messenger.SubscribeTo(this);
		}

		public void OnMessageReceived(GpuSampleAcquired message)
		{
			ArgumentMust.NotBeNull(() => message);

			GpuName = message.GpuSample.Name;
			GpuLoad.Value = message.GpuSample.GpuLoads.CoreLoad.In<Percent>().Value;
			CoreClock.Value = message.GpuSample.GpuClocks.CoreClock.In<GigaHertz>().Value;
			CoreTemperature.Value = message.GpuSample.GpuTemperature.In<Celsius>().Value;
		}

		public string GpuName
		{
			get => Get<string>();
			private set => Set(value);
		}

		public Ratio GpuLoad { get; } = new Ratio(0, Percent.Instance);

		public Frequency CoreClock { get; } = new Frequency(0, GigaHertz.Instance);

		public Temperature CoreTemperature { get; } = new Temperature(0, Celsius.Instance);
	}
}