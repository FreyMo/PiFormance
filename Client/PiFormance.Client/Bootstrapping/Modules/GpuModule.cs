namespace PiFormance.Client.Bootstrapping.Modules
{
	using Connection;
	using Core.IoC.Definitions.Container;
	using Core.IoC.Definitions.Module;
	using Services.Cpu;
	using Services.Messengers;
	using Services.Timing;
	using ViewModels;
	using ViewModels.Gpu;

	public class GpuModule : IoCModuleBase
	{
		protected override void LoadInternal()
		{
			Container.RegisterSingleton<GpuViewModel>();
			Container.RegisterSingleton<GpuSampleProviderService>();
		}

		public GpuModule(IIoCContainer container) : base(container)
		{
		}
	}
}