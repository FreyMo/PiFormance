namespace PiFormance.Client.Connection
{
	using System;

	public class ConnectionChangedEventArgs : EventArgs
	{
		public ConnectionChangedEventArgs(bool isConnected)
		{
			IsConnected = IsConnected;
		}

		public bool IsConnected { get; }
	}
}
