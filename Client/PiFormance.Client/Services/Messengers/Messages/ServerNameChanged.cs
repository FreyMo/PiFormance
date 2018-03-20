namespace PiFormance.Client.Services.Messengers.Messages
{
	using Connection;
	using Core.Standard.ArgumentMust;
	using Services;

	public class ServerNameChanged
	{
		public ServerName ServerName { get; }

		public ServerNameChanged(ServerName serverName)
		{
			ArgumentMust.NotBeNull(() => serverName);

			ServerName = serverName;
		}
	}
}