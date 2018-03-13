namespace PiFormance.Client.Services.Messengers
{
	using System.Threading;
	using Core.Standard.Messenger.Messenger;

	public class SampleMessenger : Messenger
	{
		public SampleMessenger() : base(SynchronizationContext.Current)
		{
		}
	}
}