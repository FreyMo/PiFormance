namespace PiFormance.Client.ViewModels.Gpu
{
	using Base;
	using Core.Standard.Messenger.Messenger;
	using Services.Messengers.Messages;

	public class GpuClocksViewModel : ViewModel, ISubscriberTo<GpuSampleAcquired>
	{
		public void OnMessageReceived(GpuSampleAcquired message)
		{
			throw new System.NotImplementedException();
		}
	}
}