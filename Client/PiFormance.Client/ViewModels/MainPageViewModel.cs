namespace PiFormance.Client.ViewModels
{
	using Base;
	using Core.Standard.ArgumentMust;
	using Gpu;

	public class MainPageViewModel : ViewModel
	{
		public MainPageViewModel(CoresViewModel coresViewModel, CpuViewModel cpuViewModel, RamViewModel ramViewModel, GpuViewModel gpuViewModel)
		{
			ArgumentMust.NotBeNull(() => coresViewModel);
			ArgumentMust.NotBeNull(() => cpuViewModel);
			ArgumentMust.NotBeNull(() => ramViewModel);
			ArgumentMust.NotBeNull(() => gpuViewModel);

			CoresViewModel = coresViewModel;
			CpuViewModel = cpuViewModel;
			RamViewModel = ramViewModel;
			GpuViewModel = gpuViewModel;
		}

		public CoresViewModel CoresViewModel { get; }

		public CpuViewModel CpuViewModel { get; }

		public RamViewModel RamViewModel { get; }

		public GpuViewModel GpuViewModel { get; }
	}
}