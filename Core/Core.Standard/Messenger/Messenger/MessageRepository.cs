namespace Core.Standard.Messenger.Messenger
{
	using System;
	using System.Collections.Generic;
	using ArgumentMust;
	using Extensions;

	internal class MessageRepository
	{
		private readonly Dictionary<Type, object> _messages = new Dictionary<Type, object>();

		private readonly object _thisLock = new object();

		public void RefreshWith<TMessage>(TMessage message) where TMessage : class
		{
			ArgumentMust.NotBeNull(() => message);

			lock (_thisLock)
			{
				RefreshMessageInternal(message);
			}
		}

		public TMessage Get<TMessage>() where TMessage : class
		{
			lock (_thisLock)
			{
				return GetMessageInternal<TMessage>();
			}
		}

		private TMessage GetMessageInternal<TMessage>() where TMessage : class
		{
			if (Contains<TMessage>())
			{
				return _messages[typeof(TMessage)].Cast<TMessage>();
			}

			return default(TMessage);
		}

		private void RefreshMessageInternal<TMessage>(TMessage message) where TMessage : class
		{
			if (Contains<TMessage>())
			{
				_messages[typeof(TMessage)] = message;
			}
			else
			{
				_messages.Add(typeof(TMessage), message);
			}
		}

		private bool Contains<TMessage>() where TMessage : class
		{
			return _messages.ContainsKey(typeof(TMessage));
		}
	}
}