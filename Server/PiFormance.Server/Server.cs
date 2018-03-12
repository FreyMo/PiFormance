namespace PiFormance.Server
{
	using System.Linq;
	using System.Threading;
	using Core.Standard.Dispose;
	using HardwareAccess;
	using HardwareAccess.Computer;
	using Hosts;
	using OpenHardwareMonitor.Hardware;
	using Services;

	public class Server : DisposableBase
	{
		private readonly SystemHost _systemHost;

		public Server()
		{
			var computer = new Computer
			{
				HDDEnabled = true,
				FanControllerEnabled = true,
				CPUEnabled = true,
				GPUEnabled = true,
				MainboardEnabled = true,
				RAMEnabled = true
			};
			computer.Open();

			foreach (var hardware in computer.Hardware)
			{
				System.Console.WriteLine(hardware.HardwareType);
				System.Console.WriteLine(hardware.Identifier);
				System.Console.WriteLine(hardware.Name);

				foreach (var sensor in hardware.Sensors)
				{
					hardware.Update();

					System.Console.WriteLine(sensor.SensorType);
					System.Console.WriteLine(sensor.Name);
					System.Console.WriteLine(sensor.Identifier);
					System.Console.WriteLine(sensor.Value);
				}

				System.Console.WriteLine(hardware.SubHardware);
			}

			var memoryAccess = new MemoryAccess();
			var cpuAccess = new CpuAccess(new CpuHardware(computer.Hardware.First(x => x.HardwareType == HardwareType.CPU)));

			_systemHost = new SystemHost(new SystemService(cpuAccess, memoryAccess));
		}

		protected override void DisposeManagedResources()
		{
			_systemHost.Dispose();
		}

		public void Run()
		{
			while (true)
			{
				Thread.Sleep(100);
			}
		}
	}
}