namespace Core.Standard.Messenger.DisposableMessenger
{
	using System;

	public interface IDisposableMessenger : IDisposable
	{
		void Send<TMessage>(TMessage message) where TMessage : class;

		void Post<TMessage>(TMessage message) where TMessage : class;

		void SubscribeTo<TMessage>(Action<TMessage> messageHandler) where TMessage : class;
		
		void UnsubscribeFrom<TMessage>(Action<TMessage> messageHandler) where TMessage : class;
	}
}