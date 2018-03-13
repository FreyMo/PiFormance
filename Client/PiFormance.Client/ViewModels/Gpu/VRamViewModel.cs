namespace PiFormance.Client.ViewModels.Gpu
{
	using Base;
	using Core.Standard.ArgumentMust;
	using Core.Standard.Messenger.Messenger;
	using Core.Standard.Quantities.MemoryQuantity;
	using Core.Standard.Quantities.RatioQuantity;
	using Services.Messengers;
	using Services.Messengers.Messages;

	public class VRamViewModel : ViewModel, ISubscriberTo<GpuSampleAcquired>
	{
		public VRamViewModel(SampleMessenger messenger)
		{
			ArgumentMust.NotBeNull(() => messenger);

			messenger.SubscribeTo(this);
		}

		public void OnMessageReceived(GpuSampleAcquired message)
		{
			ArgumentMust.NotBeNull(() => message);

			AvailableMemory.Value = message.GpuSample.GpuMemories.AvailableMemory.In<GibiByte>().Value;
			ReservedMemory.Value = message.GpuSample.GpuMemories.UsedMemory.In<GibiByte>().Value;
			TotalMemory.Value = message.GpuSample.GpuMemories.TotalMemory.In<GibiByte>().Value;

			Ratio.Value = message.GpuSample.GpuMemories.MemoryUsage.In<Percent>().Value;
		}

		public Memory AvailableMemory { get; } = new Memory(0, GibiByte.Instance);

		public Memory ReservedMemory { get; } = new Memory(0, GibiByte.Instance);

		public Memory TotalMemory { get; } = new Memory(0, GibiByte.Instance);

		public Ratio Ratio { get; } = new Ratio(0, Percent.Instance);
	}
}