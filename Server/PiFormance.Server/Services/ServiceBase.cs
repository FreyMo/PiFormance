namespace PiFormance.Server.Services
{
	using System.ServiceModel;
	using ServiceContracts.BaseService;

	[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
	public abstract class ServiceBase : IServiceBase
	{
	}
}