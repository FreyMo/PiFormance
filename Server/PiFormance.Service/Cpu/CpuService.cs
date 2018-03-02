namespace PiFormance.Services.Cpu
{
	using System.ServiceModel;
	using CpuRelated;

	[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
	public class CpuService : ServiceBase<ICpuCallback>, ICpuService
	{
		public Cpu GetCpu()
		{
			throw new System.NotImplementedException();
		}
	}
}