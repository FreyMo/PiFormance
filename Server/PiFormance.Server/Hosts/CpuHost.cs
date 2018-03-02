namespace PiFormance.Server.Hosts
{
	using Services.Cpu;

	public class CpuHost : HostBase<CpuService, ICpuService, ICpuCallback>
	{
		public CpuHost(ICpuService cpuService) : base(cpuService)
		{
		}
	}
}