namespace PiFormance.Server.HardwareAccess
{
	using ServiceContracts.Gpu;

	public interface IGpuAccess
	{
		GpuSample GetGpuSample();
	}
}