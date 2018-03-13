namespace PiFormance.Server.HardwareAccess.Wrappers
{
	using System;
	using System.Linq;
	using Core.Standard.ArgumentMust;
	using Core.Standard.Quantities.FrequencyQuantity;
	using Core.Standard.Quantities.MemoryQuantity;
	using Core.Standard.Quantities.RatioQuantity;
	using Core.Standard.Quantities.TemperatureQuantity;
	using OpenHardwareMonitor.Hardware;
	using ServiceContracts.Gpu;

	public class GpuSensorWrapper
	{
		private readonly IHardware _gpu;

		private ISensor _gpuTemperatureSensor;

		private ISensor _coreClockSensor;
		private ISensor _memoryClockSensor;
		private ISensor _shaderClockSensor;

		private ISensor _coreLoadSensor;
		private ISensor _memoryControllerLoadSensor;
		private ISensor _videoEngineLoadSensor;
		
		private ISensor _memoryAvailableSensor;
		private ISensor _memoryUsedSensor;
		private ISensor _memoryTotalSensor;

		public GpuSensorWrapper(IHardware gpu)
		{
			ArgumentMust.NotBeNull(() => gpu);
			if (gpu.HardwareType != HardwareType.GpuAti &&
			    gpu.HardwareType != HardwareType.GpuNvidia)
			{
				throw new ArgumentException();
			}

			_gpu = gpu;

			AssignTemperatureSensor();
			AssignClockSensors();
			AssignLoadSensors();
			AssignMemorySensors();
		}

		private void AssignTemperatureSensor()
		{
			_gpuTemperatureSensor = _gpu.Sensors.FirstOrDefault(
				x => x.SensorType == SensorType.Temperature &&
				     x.Name.Contains("Core"));
		}

		private void AssignClockSensors()
		{
			var clockSensors = _gpu.Sensors.Where(sensor => sensor.SensorType == SensorType.Clock).ToList();

			_coreClockSensor = clockSensors.FirstOrDefault(sensor => sensor.Name.Contains("Core"));
			_memoryClockSensor = clockSensors.FirstOrDefault(sensor => sensor.Name.Contains("Memory"));
			_shaderClockSensor = clockSensors.FirstOrDefault(sensor => sensor.Name.Contains("Shader"));
		}

		private void AssignLoadSensors()
		{
			var loadSensors = _gpu.Sensors.Where(sensor => sensor.SensorType == SensorType.Load).ToList();

			_coreLoadSensor = loadSensors.FirstOrDefault(sensor => sensor.Name.Contains("Core"));
			_videoEngineLoadSensor = loadSensors.FirstOrDefault(sensor => sensor.Name.Contains("Video"));
			_memoryControllerLoadSensor = loadSensors.FirstOrDefault(sensor => sensor.Name.Contains("Memory"));
		}

		private void AssignMemorySensors()
		{
			var memorySensors = _gpu.Sensors.Where(sensor => sensor.SensorType == SensorType.SmallData).ToList();

			_memoryAvailableSensor = memorySensors.FirstOrDefault(sensor => sensor.Name.Contains("Free"));
			_memoryUsedSensor = memorySensors.FirstOrDefault(sensor => sensor.Name.Contains("Used"));
			_memoryTotalSensor = memorySensors.FirstOrDefault(sensor => sensor.Name.Contains("Total"));
		}

		public string GetGpuName()
		{
			return _gpu.Name;
		}

		public GpuClocks GetGpuClocks()
		{
			_gpu.Update();

			var coreClock = _coreClockSensor.GetSensorData<Frequency, MegaHertz>();
			var memoryClock = _memoryClockSensor.GetSensorData<Frequency, MegaHertz>();
			var shaderClock = _shaderClockSensor.GetSensorData<Frequency, MegaHertz>();

			return new GpuClocks(coreClock, memoryClock, shaderClock);
		}

		public GpuLoads GetGpuLoads()
		{
			_gpu.Update();

			var coreLoad = _coreLoadSensor.GetSensorData<Ratio, Percent>();
			var memoryControllerLoad = _memoryControllerLoadSensor.GetSensorData<Ratio, Percent>();
			var videoEngineLoad = _videoEngineLoadSensor.GetSensorData<Ratio, Percent>();

			return new GpuLoads(coreLoad, memoryControllerLoad, videoEngineLoad);
		}

		public GpuMemories GetGpuMemories()
		{
			_gpu.Update();

			var availableMemory = _memoryAvailableSensor.GetSensorData<Memory, MebiByte>();
			var usedMemory = _memoryUsedSensor.GetSensorData<Memory, MebiByte>();
			var totalMemory = _memoryTotalSensor.GetSensorData<Memory, MebiByte>();

			return new GpuMemories(availableMemory, usedMemory, totalMemory);
		}

		public Temperature GetCoreTemperature()
		{
			_gpu.Update();

			return _gpuTemperatureSensor.GetSensorData<Temperature, Celsius>();
		}
	}
}