namespace PiFormance.Server.HardwareAccess
{
	using System;
	using Services.CpuRelated;

	public interface ICpuAccess : IDisposable
	{
		CpuSample GetCpuSample();
	}
}