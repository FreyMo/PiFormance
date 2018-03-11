namespace PiFormance.Client.ViewModels
{
	using Base;
	using Core.Standard.ArgumentMust;

	public class MainPageViewModel : ViewModel
	{
		public MainPageViewModel(CoresViewModel coresViewModel, CpuViewModel cpuViewModel, RamViewModel ramViewModel)
		{
			ArgumentMust.NotBeNull(() => coresViewModel);
			ArgumentMust.NotBeNull(() => cpuViewModel);
			ArgumentMust.NotBeNull(() => ramViewModel);

			CoresViewModel = coresViewModel;
			CpuViewModel = cpuViewModel;
			RamViewModel = ramViewModel;
		}

		public CoresViewModel CoresViewModel { get; }

		public CpuViewModel CpuViewModel { get; }

		public RamViewModel RamViewModel { get; }
	}
}