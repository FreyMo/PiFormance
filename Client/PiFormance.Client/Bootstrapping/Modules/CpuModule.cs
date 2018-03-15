namespace PiFormance.Client.Bootstrapping.Modules
{
	using Connection;
	using Core.IoC.Definitions.Container;
	using Core.IoC.Definitions.Module;
	using Services.Messengers;
	using Services.Providers;
	using Services.Timing;
	using ViewModels;

	internal class CpuModule : IoCModuleBase
	{
		protected override void LoadInternal()
		{
			Container.RegisterSingleton<CoresViewModel>();
			Container.RegisterSingleton<CpuViewModel>();
			Container.RegisterSingleton<MainPageViewModel>();
			Container.RegisterSingleton<RamViewModel>();

			Container.RegisterSingleton<CpuSampleProviderService>();
			Container.RegisterSingleton<RamSampleProviderService>();
			Container.RegisterSingleton<SampleMessenger>();
			Container.RegisterSingleton<CpuSampleTimerService>();

			// TODO: RELOCATE
			Container.RegisterSingleton<SystemClient>();
			Container.Resolve<CpuSampleTimerService>();
		}

		public CpuModule(IIoCContainer container) : base(container)
		{
		}
	}
}