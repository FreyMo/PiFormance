namespace PiFormance.Client.Services.Messengers
{
	using System.Threading;
	using Core.Standard.Messenger.Messenger;

	public class CpuSampleMessenger : Messenger
	{
		public CpuSampleMessenger() : base(SynchronizationContext.Current)
		{
		}
	}
}