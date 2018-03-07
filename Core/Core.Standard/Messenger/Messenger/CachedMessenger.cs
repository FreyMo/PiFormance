namespace Core.Standard.Messenger.Messenger
{
	using System.Threading;

	public abstract class CachedMessenger : Messenger, ICachedMessenger
	{
		private readonly MessageRepository _lastCachedMessages = new MessageRepository();

		protected CachedMessenger(SynchronizationContext synchonizationContext) : base(synchonizationContext)
		{
		}

		public override void Send<TMessage>(TMessage message)
		{
			base.Send(message);

			_lastCachedMessages.RefreshWith(message);
		}

		public override void Post<TMessage>(TMessage message)
		{
			base.Post(message);

			_lastCachedMessages.RefreshWith(message);
		}

		public TMessage RequestLast<TMessage>() where TMessage : class
		{
			return _lastCachedMessages.Get<TMessage>();
		}
	}
}