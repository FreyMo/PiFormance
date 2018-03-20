namespace PiFormance.Client.Services.Messengers
{
	using System.Threading;
	using Core.Standard.Messenger.Messenger;

	public class ConnectionMessenger : Messenger
	{
		public ConnectionMessenger() : base(SynchronizationContext.Current)
		{
		}
	}
}