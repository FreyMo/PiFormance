namespace PiFormance.ServiceContracts.SystemService
{
	using System.ServiceModel;
	using Cpu;
	using Memory;

	public interface ISystemCallback
	{
		[OperationContract(IsOneWay = true)]
		void CpuSampleAcquired(CpuSample cpuSample);

		[OperationContract(IsOneWay = true)]
		void RamSampleAcquired(RamSample ramSample);
	}
}