namespace PiFormance.ServiceContracts.SystemService
{
	using System.ServiceModel;
	using BaseService;

	[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
	public class SystemService : ServiceBase<ISystemCallback>, ISystemService
	{
	}
}