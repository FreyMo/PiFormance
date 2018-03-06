namespace PiFormance.Server.HardwareAccess
{
	using Services.CpuRelated;

	public interface IMemoryAccess
	{
		RamUsage GetRamUsage();
	}
}