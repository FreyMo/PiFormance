namespace Core.IoC.Definitions.ServiceLocator
{
	using System;
	using Container;
	using Standard.ArgumentMust;

	public class ServiceLocator : IServiceLocator
	{
		private readonly IIoCContainer _container;

		public ServiceLocator(IIoCContainer container)
		{
			ArgumentMust.NotBeNull(() => container);

			_container = container;
		}

		public static IServiceLocator Instance { get; private set; }

		public T Resolve<T>()
		{
			return _container.Resolve<T>();
		}

		public object ResolveType(Type type)
		{
			var genericMethod = typeof(ServiceLocator).GetMethod("Resolve").MakeGenericMethod(type);
			return genericMethod.Invoke(this, new object[] { });
		}

		public void SetStaticInstance()
		{
			if (Instance == null)
			{
				Instance = this;
			}
			else
			{
				throw new InvalidOperationException();
			}
		}
	}
}