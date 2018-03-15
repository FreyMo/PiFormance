namespace PiFormance.Client.ViewModels
{
	using Base;
	using Core.Standard.ArgumentMust;
	using Gpu;
	using Settings;

	public class MainPageViewModel : ViewModel
	{
		public MainPageViewModel(
			CoresViewModel coresViewModel,
			CpuViewModel cpuViewModel,
			RamViewModel ramViewModel,
			GpuViewModel gpuViewModel,
			GpuClocksViewModel gpuClocksViewModel,
			VRamViewModel vRamViewModel,
			GpuLoadsViewModel gpuLoadsViewModel,
			SettingsViewModel settingsViewModel)
		{
			ArgumentMust.NotBeNull(() => coresViewModel);
			ArgumentMust.NotBeNull(() => cpuViewModel);
			ArgumentMust.NotBeNull(() => ramViewModel);
			ArgumentMust.NotBeNull(() => gpuViewModel);
			ArgumentMust.NotBeNull(() => gpuClocksViewModel);
			ArgumentMust.NotBeNull(() => vRamViewModel);
			ArgumentMust.NotBeNull(() => gpuLoadsViewModel);
			ArgumentMust.NotBeNull(() => settingsViewModel);

			CoresViewModel = coresViewModel;
			CpuViewModel = cpuViewModel;
			RamViewModel = ramViewModel;
			GpuViewModel = gpuViewModel;
			GpuClocksViewModel = gpuClocksViewModel;
			VRamViewModel = vRamViewModel;
			GpuLoadsViewModel = gpuLoadsViewModel;
			SettingsViewModel = settingsViewModel;
		}

		public CoresViewModel CoresViewModel { get; }

		public CpuViewModel CpuViewModel { get; }

		public RamViewModel RamViewModel { get; }

		public GpuViewModel GpuViewModel { get; }

		public GpuClocksViewModel GpuClocksViewModel { get; }

		public VRamViewModel VRamViewModel { get; }

		public GpuLoadsViewModel GpuLoadsViewModel { get; }

		public SettingsViewModel SettingsViewModel { get; }
	}
}