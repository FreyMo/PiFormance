namespace Core.IoC.Proxies
{
	using System;
	using Definitions.Container;
	using LightInject;
	using Standard.ArgumentMust;

	public class LightInjectProxy : IoCContainerBase, IIoCContainer
	{
		private readonly LightInject.IServiceContainer _container = new ServiceContainer(new ContainerOptions {EnablePropertyInjection = false});

		public T Resolve<T>()
		{
			return _container.GetInstance<T>();
		}

		public object Resolve(Type type)
		{
			ArgumentMust.NotBeNull(() => type);

			return _container.GetInstance(type);
		}

		public void RegisterTransient<T>()
		{
			_container.Register<T>();
		}

		public void RegisterSingleton<T>()
		{
			_container.Register<T>(new PerContainerLifetime());
		}

		public void RegisterTransient<TInterface, TImplementation>() where TImplementation : class, TInterface
		{
			_container.Register<TInterface, TImplementation>();
		}

		public void RegisterSingleton<TInterface, TImplementation>() where TImplementation : class, TInterface
		{
			_container.Register<TInterface, TImplementation>(new PerContainerLifetime());
		}

		public void RegisterInstance<TInterface, TImplementation>(TImplementation instance) where TImplementation : class, TInterface
		{
			_container.RegisterInstance(typeof(TInterface), instance);
		}

		public void RegisterInstance<TImplementation>(TImplementation instance) where TImplementation : class
		{
			_container.RegisterInstance(instance);
		}
	}
}