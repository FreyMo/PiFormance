namespace PiFormance.Server.HardwareAccess.Computer
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Core.Standard.ArgumentMust;
	using Core.Standard.Quantities.FrequencyQuantity;
	using Core.Standard.Quantities.TemperatureQuantity;
	using OpenHardwareMonitor.Hardware;

	public class CpuHardware
	{
		private readonly ISensor _busClockSensor;
		private readonly ISensor _clockSensor;
		private readonly IList<ISensor> _coreTemperatureSensors;
		private readonly IHardware _cpu;
		private readonly ISensor _packageSensor;

		public CpuHardware(IHardware cpu)
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
			                     .First(x => x.SensorType == SensorType.Temperature && x.Name.Contains("Package"));

			_clockSensor = _cpu.Sensors.First(x => x.SensorType == SensorType.Clock && x.Name.Contains("Core"));
			_busClockSensor = _cpu.Sensors.First(x => x.SensorType == SensorType.Clock && x.Name.Contains("Bus"));
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
				if (sensor.Value.HasValue)
				{
					yield return new Temperature(sensor.Value.Value);
				}
			}
		}

		public Temperature GetPackageTemperature()
		{
			_cpu.Update();

			if (_packageSensor.Value.HasValue)
			{
				return new Temperature(_packageSensor.Value.Value);
			}

			return new Temperature();
		}

		public Frequency GetClockSpeed()
		{
			_cpu.Update();

			if (_clockSensor.Value.HasValue)
			{
				return new Frequency(_clockSensor.Value.Value, new MegaHertz());
			}

			return new Frequency();
		}

		public Frequency GetBusSpeed()
		{
			_cpu.Update();

			if (_busClockSensor.Value.HasValue)
			{
				return new Frequency(_busClockSensor.Value.Value, new MegaHertz());
			}

			return new Frequency();
		}
	}
}