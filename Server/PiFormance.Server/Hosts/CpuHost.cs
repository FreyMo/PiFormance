namespace PiFormance.Server.Hosts
{
	using ServiceContracts.SystemService;
	using Services;

	public class CpuHost : HostBase<SystemService, ISystemService, ISystemCallback>
	{
		public CpuHost(ISystemService systemService) : base(systemService)
		{
		}
	}
}