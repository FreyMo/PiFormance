namespace PiFormance.Server.HardwareAccess
{
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Linq;
	using Computer;
	using Core.Standard.ArgumentMust;
	using Core.Standard.Quantities.RatioQuantity.Extensions;
	using ServiceContracts.Cpu;

	public class CpuAccess : ICpuAccess
	{
		private readonly IList<PerformanceCounter> _coreLoadCounters;
		private readonly CpuHardware _cpu;
		private readonly PerformanceCounter _totalLoadCounter;

		public CpuAccess(CpuHardware cpu)
		{
			ArgumentMust.NotBeNull(() => cpu);

			_cpu = cpu;

			_totalLoadCounter = GetTotalLoadCounter();
			_coreLoadCounters = GetCoreLoadPerformanceCounters();
		}

		public CpuSample GetCpuSample()
		{
			var totalUsage = new TotalUsage(((double)_totalLoadCounter.NextValue()).Percent());

			var cores = _coreLoadCounters.Select(
				counter => new LogicalCore(int.Parse(counter.InstanceName), ((double)counter.NextValue()).Percent()));

			return new CpuSample(
				_cpu.GetCpuName(),
				_cpu.GetClockSpeed(),
				_cpu.GetBusSpeed(),
				totalUsage,
				_cpu.GetPackageTemperature(),
				cores,
				_cpu.GetCoreTemperatures());
		}

		private PerformanceCounter GetTotalLoadCounter()
		{
			return GetAllCpuLoadPerformanceCounters().Where(counter => counter.InstanceName == "_Total")
			                                         .Single(counter => counter.CounterName == "Prozessorzeit (%)");
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
	}
}