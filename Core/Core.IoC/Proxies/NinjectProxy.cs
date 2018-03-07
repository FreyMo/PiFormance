namespace Core.IoC.Proxies
{
	using System;
	using Definitions.Container;
	using Ninject;
	using Standard.ArgumentMust;

	public class NinjectProxy : IoCContainerBase, IIoCContainer
	{
		private readonly IKernel _kernel = new StandardKernel();

		public T Resolve<T>()
		{
			return _kernel.Get<T>();
		}

		public object Resolve(Type type)
		{
			ArgumentMust.NotBeNull(() => type);

			return _kernel.Get(type);
		}

		public void RegisterTransient<T>()
		{
			_kernel.Bind<T>().ToSelf().InTransientScope();
		}

		public void RegisterSingleton<T>()
		{
			_kernel.Bind<T>().ToSelf().InSingletonScope();
		}

		public void RegisterTransient<TInterface, TImplementation>() where TImplementation : class, TInterface
		{
			_kernel.Bind<TInterface>().To<TImplementation>().InTransientScope();
		}

		public void RegisterSingleton<TInterface, TImplementation>() where TImplementation : class, TInterface
		{
			_kernel.Bind<TInterface>().To<TImplementation>().InSingletonScope();
		}

		public void RegisterInstance<TInterface, TImplementation>(TImplementation instance) where TImplementation : class, TInterface
		{
			_kernel.Bind<TInterface>().ToConstant(instance);
		}

		public void RegisterInstance<TImplementation>(TImplementation instance) where TImplementation : class
		{
			_kernel.Bind<TImplementation>().ToConstant(instance);
		}
	}
}