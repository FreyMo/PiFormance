namespace PiFormance.Client.Bootstrapping.Modules
{
	using Core.IoC.Definitions.Container;
	using Core.IoC.Definitions.Module;
	using ViewModels.Settings;

	internal class SettingsModule : IoCModuleBase
	{
		public SettingsModule(IIoCContainer container) : base(container)
		{
		}

		protected override void LoadInternal()
		{
			Container.RegisterSingleton<SettingsViewModel>();
		}
	}
}