namespace PiFormance.Server.HardwareAccess.Wrappers
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Core.Standard.ArgumentMust;
	using Core.Standard.Quantities.FrequencyQuantity;
	using Core.Standard.Quantities.TemperatureQuantity;
	using OpenHardwareMonitor.Hardware;

	public class CpuSensorWrapper
	{
		private readonly ISensor _busClockSensor;
		private readonly ISensor _clockSensor;
		private readonly IList<ISensor> _coreTemperatureSensors;
		private readonly IHardware _cpu;
		private readonly ISensor _packageSensor;

		public CpuSensorWrapper(IHardware cpu)
		{
			ArgumentMust.NotBeNull(() => cpu);
			if (cpu.HardwareType != HardwareType.CPU)
			{
				throw new ArgumentException();
			}

			_cpu = cpu;

			_coreTemperatureSensors = _cpu.Sensors
			                              .Where(x => x.SensorType == SensorType.Temperature)
			                              .Where(x => x.Name.Contains("Core"))
			                              .OrderBy(x => x.Identifier)
			                              .ToList();

			_packageSensor = _cpu.Sensors
			                     .FirstOrDefault(x => x.SensorType == SensorType.Temperature && x.Name.Contains("Package"));

			_clockSensor = _cpu.Sensors.FirstOrDefault(x => x.SensorType == SensorType.Clock && x.Name.Contains("Core"));
			_busClockSensor = _cpu.Sensors.FirstOrDefault(x => x.SensorType == SensorType.Clock && x.Name.Contains("Bus"));
		}

		public string GetCpuName()
		{
			return _cpu.Name;
		}

		public IEnumerable<Temperature> GetCoreTemperatures()
		{
			_cpu.Update();

			foreach (var sensor in _coreTemperatureSensors)
			{
				yield return sensor.GetSensorData<Temperature, Celsius>();
			}
		}

		public Temperature GetPackageTemperature()
		{
			_cpu.Update();

			return _packageSensor.GetSensorData<Temperature, Celsius>();
		}

		public Frequency GetClockSpeed()
		{
			_cpu.Update();

			return _clockSensor.GetSensorData<Frequency, MegaHertz>();
		}

		public Frequency GetBusSpeed()
		{
			_cpu.Update();

			return _busClockSensor.GetSensorData<Frequency, MegaHertz>();
		}
	}
}