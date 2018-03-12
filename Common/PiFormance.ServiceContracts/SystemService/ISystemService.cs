namespace PiFormance.ServiceContracts.SystemService
{
	using System.ServiceModel;
	using BaseService;
	using Cpu;
	using Gpu;
	using Memory;

	[ServiceContract]
	public interface ISystemService : IServiceBase
	{
		[OperationContract(IsOneWay = false)]
		CpuSample GetCpuSample();

		[OperationContract(IsOneWay = false)]
		RamSample GetRamSample();

		[OperationContract(IsOneWay = false)]
		GpuSample GetGpuSample();
	}
}