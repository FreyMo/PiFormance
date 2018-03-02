namespace PiFormance.Services
{
	using System.ServiceModel;

	[ServiceContract]
	public interface IServiceBase<out TCallback>
	{
		TCallback Callback { get; }

		[OperationContract(IsOneWay = true)]
		void Acknowledge();
	}
}