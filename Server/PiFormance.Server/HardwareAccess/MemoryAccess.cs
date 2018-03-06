namespace PiFormance.Server.HardwareAccess
{
	using Core.Common.Quantities.MemoryQuantity;
	using Core.Common.Quantities.MemoryQuantity.Extensions;
	using Microsoft.VisualBasic.Devices;
	using Services.CpuRelated;

	public class MemoryAccess : IMemoryAccess
	{
		private readonly ComputerInfo _computerInfo = new ComputerInfo();

		public RamUsage GetRamUsage()
		{
			return new RamUsage(
				((double)_computerInfo.TotalPhysicalMemory).Bytes().In<GibiByte>(),
				((double)_computerInfo.AvailablePhysicalMemory).Bytes().In<GibiByte>());
		}
	}
}