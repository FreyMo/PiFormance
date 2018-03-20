namespace PiFormance.Client.Bootstrapping.Modules
{
	using Core.IoC.Definitions.Container;
	using Core.IoC.Definitions.Module;
	using Services;
	using Services.Connection;
	using Services.Messengers;
	using ViewModels.Settings;

	internal class SettingsModule : IoCModuleBase
	{
		public SettingsModule(IIoCContainer container) : base(container)
		{
		}

		protected override void LoadInternal()
		{
			Container.RegisterSingleton<SettingsViewModel>();

			Container.RegisterSingleton<ConnectionMessenger>();
			Container.RegisterSingleton<ConnectionSettingsService>();
		}
	}
}