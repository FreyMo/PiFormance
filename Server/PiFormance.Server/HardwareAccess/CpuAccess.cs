namespace PiFormance.Server.HardwareAccess
{
	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Linq;
	using System.Management;
	using Core.Common.Dispose;
	using Core.Common.Quantities.FrequencyQuantity;
	using Core.Common.Quantities.FrequencyQuantity.Extensions;
	using Core.Common.Quantities.RatioQuantity;
	using Core.Common.Quantities.TemperatureQuantity;
	using Services.CpuRelated;

	public class CpuAccess : DisposableBase, ICpuAccess
	{
		private readonly IList<PerformanceCounter> _cpuLoadCounters;
		private readonly ManagementObject _managementObject = new ManagementObject("Win32_Processor.DeviceID='CPU0'");

		public CpuAccess()
		{
			_cpuLoadCounters = GetCpuLoadPerformanceCounters().ToList();

			Console.WriteLine(GetCpuSpeed().In<GigaHertz>());
		}
		
		public CpuSample GetCpuSample()
		{
			return new CpuSample(
				GetCpuSpeed(),
				_cpuLoadCounters.Select(
					counter => new Core(
						int.Parse(counter.InstanceName),
						new ThermalReading(50, Celsius.Instance),
						new Load(counter.NextValue(), Percent.Instance))));
		}

		private Frequency GetCpuSpeed()
		{
			return ((int)(uint)_managementObject["CurrentClockSpeed"]).MegaHertz();
		}

		private IList<PerformanceCounter> GetCpuLoadPerformanceCounters()
		{
			var processorCategory = PerformanceCounterCategory.GetCategories().Single(x => x.CategoryName == "Prozessor");
			var counters = processorCategory.GetInstanceNames()
			                                .Where(instanceName => instanceName != "_Total")
			                                .SelectMany(instanceName => processorCategory.GetCounters(instanceName))
			                                .Where(counter => counter.CounterName == "Prozessorzeit (%)")
			                                .OrderBy(counter => counter.InstanceName)
			                                .ToList();

			counters.ForEach(counter => counter.NextValue());

			return counters;
		}

		protected override void DisposeManagedResources()
		{
			_managementObject.Dispose();
		}
	}
}