namespace PiFormance.Client.Connection
{
	using Connected_Services.Cpu;

	public interface ICpuClient : ICpuService, IClient<ICpuService, ICpuServiceCallback>
	{
	}
}