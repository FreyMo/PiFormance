﻿namespace PiFormance.Server.HardwareAccess
{
	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Linq;
	using System.Management;
	using Core.Standard.Dispose;
	using Core.Standard.Quantities.FrequencyQuantity;
	using Core.Standard.Quantities.FrequencyQuantity.Extensions;
	using Core.Standard.Quantities.RatioQuantity.Extensions;
	using Core.Standard.Quantities.TemperatureQuantity.Extensions;
	using ServiceContracts.Cpu;

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
			var cores = _cpuLoadCounters.Select(
				counter => new LogicalCore(int.Parse(counter.InstanceName), 50.DegreesCelsius(), ((double)counter.NextValue()).Percent()));

			return new CpuSample(GetCpuSpeed(), cores);
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