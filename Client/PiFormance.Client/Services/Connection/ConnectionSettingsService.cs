namespace PiFormance.Client.Services.Connection
{
	using Core.Standard.ArgumentMust;
	using Core.Standard.Notification;
	using Messengers;
	using Messengers.Messages;

	public class ConnectionSettingsService : Bindable
	{
		private readonly ConnectionMessenger _messenger;

		public ConnectionSettingsService(ConnectionMessenger messenger)
		{
			ArgumentMust.NotBeNull(() => messenger);

			_messenger = messenger;

			ServerName = new ServerName();
		}

		public ServerName ServerName
		{
			get => Get<ServerName>();
			private set
			{
				if (Set(value))
				{
					_messenger.Post(new ServerNameChanged(value));
				}
			}
		}

		public void ReconnectTo(ServerName serverName)
		{
			ArgumentMust.NotBeNull(() => serverName);

			ServerName = serverName;

			_messenger.Post(new ReconnectRequested());
		}
	}
}