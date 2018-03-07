namespace PiFormance.ServiceContracts.SystemService
{
	using System.ServiceModel;
	using BaseService;

	[ServiceContract(CallbackContract = typeof(ISystemCallback))]
	public interface ISystemService : IServiceBase<ISystemCallback>
	{
	}
}