namespace PiFormance.Services.Cpu
{
	using System.ServiceModel;

	[ServiceContract(CallbackContract = typeof(ICpuCallback))]
	public interface ICpuService : IServiceBase<ICpuCallback>
	{
	}
}