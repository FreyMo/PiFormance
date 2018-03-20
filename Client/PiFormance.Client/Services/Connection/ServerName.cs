namespace PiFormance.Client.Services.Connection
{
	using Core.Standard.ArgumentMust;

	public class ServerName
	{
		public ServerName() : this("localhost")
		{
		}

		public ServerName(string serverName)
		{
			ArgumentMust.NotBeNull(() => serverName);

			if (string.IsNullOrWhiteSpace(serverName))
			{
				AsString = "localhost";
			}
			else
			{
				AsString = serverName;
			}
		}

		public string AsString { get; }
	}
}