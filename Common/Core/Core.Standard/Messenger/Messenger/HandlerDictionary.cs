namespace Core.Standard.Messenger.Messenger
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using ArgumentMust;
	using Extensions;

	internal class HandlerDictionary : Dictionary<Type, Handlers>
	{
		private readonly object _thisLock = new object();

		public void AddHandler<TMessage>(ISubscriberTo<TMessage> subscriberTo) where TMessage : class
		{
			ArgumentMust.NotBeNull(() => subscriberTo);

			lock (_thisLock)
			{
				AddHandlerPrivate(subscriberTo);
			}
		}

		public void RemoveHandler<TMessage>(ISubscriberTo<TMessage> subscriberTo) where TMessage : class
		{
			ArgumentMust.NotBeNull(() => subscriberTo);

			lock (_thisLock)
			{
				RemoveHandlerPrivate(subscriberTo);
			}
		}
		
		public void InvalidateHandlers()
		{
			var deadReferences = this.SelectMany(kvp => kvp.Value.Where(wr => !wr.IsAlive)).ToList();

			deadReferences.ForEach(Delete);
		}

		private void AddHandlerPrivate<TMessage>(ISubscriberTo<TMessage> subscriberTo) where TMessage : class
		{
			if (ContainsKey(typeof(TMessage)))
			{
				if (this[typeof(TMessage)].All(wr => wr.Target.As<ISubscriberTo<TMessage>>() != subscriberTo))
				{
					this[typeof(TMessage)].Add(new WeakReference(subscriberTo));
				}
			}
			else
			{
				Add(typeof(TMessage), new Handlers(new WeakReference(subscriberTo)));
			}

			InvalidateHandlers();
		}

		private void RemoveHandlerPrivate<TMessage>(ISubscriberTo<TMessage> subscriberTo) where TMessage : class
		{
			if (ContainsKey(typeof(TMessage)))
			{
				this[typeof(TMessage)].RemoveAll(wr => wr.Target.As<ISubscriberTo<TMessage>>() == subscriberTo);
			}

			InvalidateHandlers();
		}

		private void Delete(WeakReference deadReference)
		{
			var allReferences = this.Select(kvp => kvp.Value).Where(wr => wr.Contains(deadReference));

			allReferences.ForEach(handlers => handlers.RemoveAll(reference => reference.Equals(deadReference)));
		}
	}
}