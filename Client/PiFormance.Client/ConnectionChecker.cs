namespace PiFormance.Client
{
	using System.Collections.Generic;
	using System.Linq;
	using System.Net;
	using System.Net.NetworkInformation;
	using System.Net.Sockets;

	public class ConnectionChecker
	{
		public IEnumerable<IPAddress> GetEligableAddresses()
		{
			var interfaces = NetworkInterface.GetAllNetworkInterfaces();

			var addresses = interfaces.SelectMany(networkInterface => networkInterface.GetIPProperties().UnicastAddresses)
									  .Where(ip => ip.IsDnsEligible)
									  .Select(ip => ip.Address)
									  .Where(address => !IPAddress.IsLoopback(address))
									  .Where(address => address.AddressFamily == AddressFamily.InterNetwork)
									  .ToList();

			var hosts = Windows.Networking.Connectivity.NetworkInformation.GetHostNames().ToList();
			foreach (var host in hosts)
			{
				string IP = host.DisplayName;
			}

			if (addresses.Count > 1)
			{
				return addresses.Except(new[] { GetLocalIpAddress() });
			}

			return addresses;
		}

		private IPAddress GetLocalIpAddress()
		{
			return Dns.GetHostAddresses(Dns.GetHostName()).First(ip => ip.AddressFamily == AddressFamily.InterNetwork);
		}
	}
}