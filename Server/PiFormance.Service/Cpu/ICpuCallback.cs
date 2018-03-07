namespace PiFormance.Services.Cpu
{
	using System.ServiceModel;
	using CpuRelated;

	public interface ICpuCallback
	{
		[OperationContract(IsOneWay = true)]
		void CpuChanged(CpuSample cpuSample);

		[OperationContract(IsOneWay = true)]
		void RamUsageChanged(RamSample ramSample);
	}
}