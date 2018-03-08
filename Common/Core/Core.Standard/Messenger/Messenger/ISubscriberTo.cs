namespace Core.Standard.Messenger.Messenger
{
	public interface ISubscriberTo<in TMessage> where TMessage : class
	{
		void OnMessageReceived(TMessage message);
	}
}