namespace PiFormance.Client
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Net;
	using System.Net.NetworkInformation;
	using System.Net.Sockets;
	using Windows.Networking.Connectivity;

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

			var addressesssss = interfaces.Select(ni => ni.GetIPProperties());

			var temp = Dns.GetHostAddresses("MORITZ-PC");

			var names = Dns.GetHostName();

			var hosts = NetworkInformation.GetHostNames().ToList();
			var profiles = NetworkInformation.GetConnectionProfiles();
			var lanIdentifiers = NetworkInformation.GetLanIdentifiers();
			
			foreach (var host in hosts)
			{
				string IP = host.DisplayName;
			}

			if (addresses.Count > 1)
			{
				return addresses.Except(new[] { GetLocalIpAddress() });
			}

			string strHostName;

			// Getting Ip address of local machine...
			// First get the host name of local machine.
			strHostName = Dns.GetHostName();
			Console.WriteLine("Local Machine's Host Name: " + strHostName);

			IPHostEntry remoteIP;

			//using host name, get the IP address list..
			IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
			IPAddress[] addr = ipEntry.AddressList;

			int i = 0;
			while (i < addr.Length)
			{
				Console.WriteLine("IP Address {0}: {1} ", i, addr[i].ToString());
				//HostNames
				remoteIP = Dns.GetHostEntry((addr[i]));
				Console.WriteLine("HostName {0}: {1} ", i, remoteIP.HostName);
				i++;
			}



			return addresses;
		}

		private IPAddress GetLocalIpAddress()
		{
			return Dns.GetHostAddresses(Dns.GetHostName()).First(ip => ip.AddressFamily == AddressFamily.InterNetwork);
		}
	}
}