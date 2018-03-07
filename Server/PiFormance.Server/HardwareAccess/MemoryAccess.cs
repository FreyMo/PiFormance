namespace PiFormance.Server.HardwareAccess
{
	using Core.Standard.Quantities.MemoryQuantity;
	using Core.Standard.Quantities.MemoryQuantity.Extensions;
	using Microsoft.VisualBasic.Devices;
	using ServiceContracts.Memory;

	public class MemoryAccess : IMemoryAccess
	{
		private readonly ComputerInfo _computerInfo = new ComputerInfo();

		public RamSample GetRamUsage()
		{
			return new RamSample(
				((double)_computerInfo.TotalPhysicalMemory).Bytes().In<GibiByte>(),
				((double)_computerInfo.AvailablePhysicalMemory).Bytes().In<GibiByte>());
		}
	}
}