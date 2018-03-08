namespace Core.Standard.Messenger.Messenger
{
	public interface IMessenger
	{
		void Send<TMessage>(TMessage message) where TMessage : class;

		void Post<TMessage>(TMessage message) where TMessage : class;

		void SubscribeTo<TMessage>(ISubscriberTo<TMessage> subscriberTo) where TMessage : class;

		void UnsubscribeFrom<TMessage>(ISubscriberTo<TMessage> subscriberTo) where TMessage : class;
	}
}