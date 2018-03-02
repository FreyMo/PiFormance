namespace PiFormance.Client.Connection
{
	using System;

	public interface IClient<TService, in TServiceCallback>
	{
		event EventHandler<ConnectionChangedEventArgs> ConnectionChanged;

		bool IsConnected { get; }

		void AttachCallback(TServiceCallback serviceCallback);

		void DetachCallback(TServiceCallback serviceCallback);
	}
}
