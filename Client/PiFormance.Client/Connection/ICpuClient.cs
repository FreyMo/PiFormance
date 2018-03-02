namespace PiFormance.Client.Connection
{
	using Cpu;

	public interface ICpuClient : ICpuService, IClient<ICpuService, ICpuServiceCallback>
	{
	}
}