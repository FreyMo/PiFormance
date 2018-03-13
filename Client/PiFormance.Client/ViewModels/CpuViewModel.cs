namespace PiFormance.Client.ViewModels
{
	using Base;
	using Core.Standard.ArgumentMust;
	using Core.Standard.Messenger.Messenger;
	using Core.Standard.Quantities.FrequencyQuantity;
	using Core.Standard.Quantities.RatioQuantity;
	using Services.Messengers;
	using Services.Messengers.Messages;

	public class CpuViewModel : ViewModel, ISubscriberTo<CpuSampleAcquired>
	{
		public CpuViewModel(SampleMessenger messenger)
		{
			ArgumentMust.NotBeNull(() => messenger);

			messenger.SubscribeTo(this);

			messenger.Post(new SamplesShouldBeAcquired());
		}

		public void OnMessageReceived(CpuSampleAcquired message)
		{
			ArgumentMust.NotBeNull(() => message);

			CpuName = message.CpuSample.Name;
			TotalLoad.Value = message.CpuSample.TotalUsage.Load.In<Percent>().Value;
			ClockSpeed.Value = message.CpuSample.ClockSpeed.In<GigaHertz>().Value;
		}

		public string CpuName
		{
			get => Get<string>();
			private set => Set(value);
		}

		public Ratio TotalLoad { get; } = new Ratio(0, Percent.Instance);

		public Frequency ClockSpeed { get; } = new Frequency(0, GigaHertz.Instance);
	}
}