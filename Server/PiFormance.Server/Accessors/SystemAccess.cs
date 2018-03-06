namespace PiFormance.Server.Accessors
{
	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Linq;
	using System.Management;
	using Core.Common.Dispose;
	using Core.Common.Quantities.FrequencyQuantity;
	using Core.Common.Quantities.FrequencyQuantity.Extensions;
	using Core.Common.Quantities.MemoryQuantity.Extensions;
	using Core.Common.Quantities.RatioQuantity;
	using Microsoft.VisualBasic.Devices;
	using Services.CpuRelated;

	public class SystemAccess : DisposableBase
	{
		private readonly ComputerInfo _computerInfo = new ComputerInfo();
		private readonly IList<PerformanceCounter> _cpuLoadCounters;
		private readonly ManagementObject _managementObject = new ManagementObject("Win32_Processor.DeviceID='CPU0'");

		public SystemAccess()
		{
			_cpuLoadCounters = GetCpuLoadPerformanceCounters().ToList();

			Console.WriteLine(GetCpuSpeed().In<GigaHertz>());
		}

		public RamUsage GetRamUsage()
		{
			return new RamUsage(
				((double)_computerInfo.TotalPhysicalMemory).Bytes(),
				((double)_computerInfo.AvailablePhysicalMemory).Bytes());
		}

		public Cpu GetCpu()
		{
			return new Cpu(
				GetCpuSpeed(),
				_cpuLoadCounters.Select(
					counter => new Core(int.Parse(counter.InstanceName), new Temperature(), new Load(counter.NextValue(), Percent.Instance))));
		}

		public Frequency GetCpuSpeed()
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