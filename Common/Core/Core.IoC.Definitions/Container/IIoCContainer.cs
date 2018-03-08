namespace Core.IoC.Definitions.Container
{
	using System;

	public interface IIoCContainer : IIoCContainerBase
	{
		T Resolve<T>();

		object Resolve(Type type);

		void RegisterTransient<T>();

		void RegisterSingleton<T>();

		void RegisterTransient<TInterface, TImplementation>() where TImplementation : class, TInterface;

		void RegisterSingleton<TInterface, TImplementation>() where TImplementation : class, TInterface;

		void RegisterInstance<TInterface, TImplementation>(TImplementation instance) where TImplementation : class, TInterface;

		void RegisterInstance<TImplementation>(TImplementation instance) where TImplementation : class;
	}
}