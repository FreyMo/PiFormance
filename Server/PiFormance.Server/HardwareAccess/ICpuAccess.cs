namespace PiFormance.Server.HardwareAccess
{
	using ServiceContracts.Cpu;

	public interface ICpuAccess
	{
		CpuSample GetCpuSample();
	}
}