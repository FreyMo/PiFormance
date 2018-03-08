namespace PiFormance.Server.Services
{
	using System;
	using System.ServiceModel;
	using ServiceContracts.BaseService;

	[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
	public abstract class ServiceBase<TCallback> : IServiceBase<TCallback>
		where TCallback : class
	{
		private OperationContext _operationContext;

		public TCallback Callback => _operationContext?.GetCallbackChannel<TCallback>();

		public void Acknowledge()
		{
			Console.WriteLine("SOMEONE CALLED ME!");

			_operationContext = OperationContext.Current;
		}
	}
}