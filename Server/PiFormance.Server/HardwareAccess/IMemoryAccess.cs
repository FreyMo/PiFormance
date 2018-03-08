namespace PiFormance.Server.HardwareAccess
{
	using ServiceContracts.Memory;

	public interface IMemoryAccess
	{
		RamSample GetRamSample();
	}
}