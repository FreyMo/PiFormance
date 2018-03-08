namespace PiFormance.Server.Hosts
{
	using ServiceContracts.SystemService;

	public class SystemHost : HostBase<ISystemService>
	{
		public SystemHost(ISystemService systemService) : base(systemService)
		{
		}
	}
}