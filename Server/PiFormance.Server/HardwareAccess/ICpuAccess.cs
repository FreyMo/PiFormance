namespace PiFormance.Server.HardwareAccess
{
	using System;
	using ServiceContracts.Cpu;

	public interface ICpuAccess : IDisposable
	{
		CpuSample GetCpuSample();
	}
}