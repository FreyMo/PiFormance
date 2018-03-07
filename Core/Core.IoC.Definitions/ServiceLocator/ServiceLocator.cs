namespace Core.IoC.Definitions.ServiceLocator
{
	using System;
	using Container;

	public class ServiceLocator : IServiceLocator
	{
		private readonly IIoCContainer _container;

		private ServiceLocator(IIoCContainer container)
		{
			_container = container;
		}

		public static ServiceLocator Instance { get; private set; }

		public T Resolve<T>()
		{
			return Instance._container.Resolve<T>();
		}

		public object ResolveType(Type type)
		{
			var genericMethod = typeof(ServiceLocator).GetMethod("Resolve").MakeGenericMethod(type);
			return genericMethod.Invoke(Instance, new object[] { });
		}

		private static void CreateInstance(IIoCContainer container)
		{
			Instance = new ServiceLocator(container);
		}
	}
}