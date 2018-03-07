namespace Core.Standard.Messenger.Messenger
{
	using System;
	using System.Linq;
	using System.Threading;
	using ArgumentMust;
	using Extensions;

	public abstract class Messenger : IMessenger
	{
		private readonly SynchronizationContext _synchronizationContext;

		private readonly HandlerDictionary _handlers = new HandlerDictionary();

		protected Messenger(SynchronizationContext synchonizationContext)
		{
			_synchronizationContext = synchonizationContext;
		}

		public virtual void Send<TMessage>(TMessage message) where TMessage : class
		{
			ArgumentMust.NotBeNull(() => message);

			PublishMessage((x, y) => _synchronizationContext.Send(x, y), message);
		}

		public virtual void Post<TMessage>(TMessage message) where TMessage : class
		{
			ArgumentMust.NotBeNull(() => message);

			PublishMessage((x, y) => _synchronizationContext.Post(x, y), message);
		}

		public void SubscribeTo<TMessage>(ISubscriberTo<TMessage> subscriberTo) where TMessage : class
		{
			ArgumentMust.NotBeNull(() => subscriberTo);

			_handlers.AddHandler(subscriberTo);
		}

		public void UnsubscribeFrom<TMessage>(ISubscriberTo<TMessage> subscriberTo) where TMessage : class
		{
			ArgumentMust.NotBeNull(() => subscriberTo);

			_handlers.RemoveHandler(subscriberTo);
		}

		private void DispatchAction<TMessage>(TMessage message) where TMessage : class
		{
			if (_handlers.ContainsKey(typeof(TMessage)))
			{
				_handlers.InvalidateHandlers();
				// _handlers[typeof(TMessage)].ForEach(wr => wr.Target.As<ISubscriberTo<TMessage>>()?.OnMessageReceived(message)); <-- as it was before, there was an exception...
				_handlers[typeof(TMessage)].Where(x => x.IsAlive).ToList().ForEach(wr => wr.Target.As<ISubscriberTo<TMessage>>()?.OnMessageReceived(message));
			}
		}

		private void PublishMessage<TMessage>(Action<SendOrPostCallback, object> sendOrPostAction, TMessage message)
			where TMessage : class
		{
			if (_synchronizationContext != null)
			{
				sendOrPostAction(m => DispatchAction(m.Cast<TMessage>()), message);
			}
			else
			{
				DispatchAction(message);
			}
		}
	}
}