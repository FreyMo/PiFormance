namespace PiFormance.Server.HardwareAccess
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
	using ServiceContracts.Cpu;

	public class CpuAccess : DisposableBase, ICpuAccess
	{
		private readonly PerformanceCounter _totalLoadCounter;
		private readonly IList<PerformanceCounter> _coreLoadCounters;
		private readonly ManagementObject _managementObject = new ManagementObject("Win32_Processor.DeviceID='CPU0'");

		public CpuAccess()
		{
			_totalLoadCounter = GetTotalLoadCounter();
			_coreLoadCounters = GetCoreLoadPerformanceCounters();
		}

		private PerformanceCounter GetTotalLoadCounter()
		{
			return GetAllCpuLoadPerformanceCounters().Where(counter => counter.InstanceName == "_Total")
													 .Single(counter => counter.CounterName == "Prozessorzeit (%)");
		}

		public CpuSample GetCpuSample()
		{
			var totalUsage = new TotalUsage(((double)_totalLoadCounter.NextValue()).Percent());

			var cores = _coreLoadCounters.Select(
				counter => new LogicalCore(int.Parse(counter.InstanceName), ((double)counter.NextValue()).Percent()));

			return new CpuSample(GetCpuSpeed(), totalUsage, cores);
		}

		private Frequency GetCpuSpeed()
		{
			return ((int)(uint)_managementObject["CurrentClockSpeed"]).MegaHertz();
		}

		private IList<PerformanceCounter> GetCoreLoadPerformanceCounters()
		{
			var counters = GetAllCpuLoadPerformanceCounters().Where(counter => counter.InstanceName != "_Total")
			                                                 .Where(counter => counter.CounterName == "Prozessorzeit (%)")
			                                                 .OrderBy(counter => counter.InstanceName)
			                                                 .ToList();

			counters.ForEach(counter => counter.NextValue());

			return counters;
		}

		private IEnumerable<PerformanceCounter> GetAllCpuLoadPerformanceCounters()
		{
			var processorCategory = PerformanceCounterCategory.GetCategories().Single(x => x.CategoryName == "Prozessor");

			return processorCategory.GetInstanceNames()
			                        .SelectMany(instanceName => processorCategory.GetCounters(instanceName));
		}

		protected override void DisposeManagedResources()
		{
			_managementObject.Dispose();
		}
	}
}