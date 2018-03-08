namespace PiFormance.Client.Connection
{
	using ServiceContracts.SystemService;

	public interface ISystemClient : ISystemService, IClient<ISystemService>
	{
	}
}