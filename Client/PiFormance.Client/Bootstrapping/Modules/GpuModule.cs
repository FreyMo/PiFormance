namespace PiFormance.Client.Bootstrapping.Modules
{
	using Core.IoC.Definitions.Container;
	using Core.IoC.Definitions.Module;
	using Services.Cpu;
	using ViewModels.Gpu;

	public class GpuModule : IoCModuleBase
	{
		public GpuModule(IIoCContainer container) : base(container)
		{
		}

		protected override void LoadInternal()
		{
			Container.RegisterSingleton<GpuViewModel>();
			Container.RegisterSingleton<GpuClocksViewModel>();
			Container.RegisterSingleton<VRamViewModel>();
			Container.RegisterSingleton<GpuLoadsViewModel>();

			Container.RegisterSingleton<GpuSampleProviderService>();
		}
	}
}