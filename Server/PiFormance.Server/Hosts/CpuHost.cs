namespace PiFormance.Server.Hosts
{
	using ServiceContracts.SystemService;

	public class CpuHost : HostBase<SystemService, ISystemService, ISystemCallback>
	{
		public CpuHost(ISystemService systemService) : base(systemService)
		{
		}
	}
}