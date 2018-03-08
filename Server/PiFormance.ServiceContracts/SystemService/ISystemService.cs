namespace PiFormance.ServiceContracts.SystemService
{
	using System.ServiceModel;
	using BaseService;
	using Cpu;
	using Memory;

	[ServiceContract(CallbackContract = typeof(ISystemCallback))]
	public interface ISystemService : IServiceBase<ISystemCallback>
	{
		[OperationContract(IsOneWay = false)]
		CpuSample GetCpuSample();

		[OperationContract(IsOneWay = false)]
		RamSample GetRamSample();
	}
}