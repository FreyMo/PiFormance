namespace PiFormance.Client.ViewModels.Gpu
{
	using Base;
	using Core.Standard.ArgumentMust;
	using Core.Standard.Messenger.Messenger;
	using Core.Standard.Quantities.RatioQuantity;
	using Services.Messengers;
	using Services.Messengers.Messages;

	public class GpuLoadsViewModel : ViewModel, ISubscriberTo<GpuSampleAcquired>
	{
		public GpuLoadsViewModel(SampleMessenger messenger)
		{
			ArgumentMust.NotBeNull(() => messenger);

			messenger.SubscribeTo(this);
		}

		public void OnMessageReceived(GpuSampleAcquired message)
		{
			ArgumentMust.NotBeNull(() => message);

			GpuLoad.Value = message.GpuSample.GpuLoads.CoreLoad.In<Percent>().Value;
			McuLoad.Value = message.GpuSample.GpuLoads.MemoryControllerLoad.In<Percent>().Value;
			VideoEngineLoad.Value = message.GpuSample.GpuLoads.VideoEngineLoad.In<Percent>().Value;
		}

		public Ratio GpuLoad { get; } = new Ratio(0, Percent.Instance);

		public Ratio McuLoad { get; } = new Ratio(0, Percent.Instance);

		public Ratio VideoEngineLoad { get; } = new Ratio(0, Percent.Instance);
	}
}