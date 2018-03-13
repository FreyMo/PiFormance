namespace PiFormance.Client.Connection
{
	using System.Linq;
	using System.Net;
	using System.Net.Sockets;

	public class ConnectionChecker
	{
		public IPAddress GetServerAddress()
		{
			try
			{
				return Dns.GetHostAddresses("MARIUS-PC").Single(x => x.AddressFamily == AddressFamily.InterNetwork);
			}
			catch (SocketException)
			{
				return Dns.GetHostAddresses("MORITZ-PC").Single(x => x.AddressFamily == AddressFamily.InterNetwork);
			}
		}

		private IPAddress GetLocalIpAddress()
		{
			return Dns.GetHostAddresses(Dns.GetHostName()).Single(ip => ip.AddressFamily == AddressFamily.InterNetwork);
		}
	}
}