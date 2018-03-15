namespace PiFormance.Server.HardwareAccess
{
	using Core.Standard.ArgumentMust;
	using ServiceContracts.Gpu;
	using Wrappers;

	public class GpuAccess : IGpuAccess
	{
		private readonly GpuSensorWrapper _gpu;

		public GpuAccess(GpuSensorWrapper gpu)
		{
			ArgumentMust.NotBeNull(() => gpu);

			_gpu = gpu;
		}

		public GpuSample GetGpuSample()
		{
			_gpu.UpdateSensors();

			return new GpuSample(
				_gpu.GetGpuName(),
				_gpu.GetGpuClocks(),
				_gpu.GetGpuLoads(),
				_gpu.GetGpuMemories(),
				_gpu.GetCoreTemperature());
		}
	}
}