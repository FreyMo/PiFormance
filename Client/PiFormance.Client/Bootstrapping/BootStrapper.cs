namespace PiFormance.Client.Bootstrapping
{
	using Core.IoC;
	using Core.IoC.Adapters;
	using Core.IoC.Definitions.Container;
	using Core.IoC.Definitions.ServiceLocator;
	using Modules;

	internal class Bootstrapper
	{
		private readonly IIoCContainer _container;

		internal Bootstrapper()
		{
			_container = DependencyInjection.By<LightInjectAdapter>();
			
			RegisterServiceLocator();
			LoadModules();
		}

		private void RegisterServiceLocator()
		{
			var serviceLocator = new ServiceLocator(_container);
			serviceLocator.SetStaticInstance();

			_container.RegisterInstance<IServiceLocator>(serviceLocator);
		}

		private void LoadModules()
		{
			_container.Load(new CpuModule(_container));
			_container.Load(new GpuModule(_container));
		}
	}
}