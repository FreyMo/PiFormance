namespace PiFormance.Client
{
	using System.Collections.Generic;
	using System.Linq;
	using System.Net;
	using System.Net.Sockets;

	public class ConnectionChecker
	{
		public IEnumerable<IPAddress> GetEligableAddresses()
		{
			yield return Dns.GetHostAddresses("MORITZ-PC").Single(x => x.AddressFamily == AddressFamily.InterNetwork);
		}

		private IPAddress GetLocalIpAddress()
		{
			return Dns.GetHostAddresses(Dns.GetHostName()).Single(ip => ip.AddressFamily == AddressFamily.InterNetwork);
		}
	}
}