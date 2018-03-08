namespace PiFormance.Client.Connection
{
	using System;

	public interface IClient<TService>
	{
		event EventHandler<ConnectionChangedEventArgs> ConnectionChanged;

		bool IsConnected { get; }
	}
}
