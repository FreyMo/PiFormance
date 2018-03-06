namespace PiFormance.Services.Cpu
{
	using System.ServiceModel;

	[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
	public class CpuService : ServiceBase<ICpuCallback>, ICpuService
	{
	}
}