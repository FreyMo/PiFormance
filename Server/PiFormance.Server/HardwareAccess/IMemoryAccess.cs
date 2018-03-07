namespace PiFormance.Server.HardwareAccess
{
	using Services.CpuRelated;

	public interface IMemoryAccess
	{
		RamSample GetRamUsage();
	}
}