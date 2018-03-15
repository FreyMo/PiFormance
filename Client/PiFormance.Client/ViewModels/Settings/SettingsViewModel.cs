namespace PiFormance.Client.ViewModels.Settings
{
	using System.Threading.Tasks;
	using System.Windows.Input;
	using Base;
	using Core.Standard.Commands.AsyncCommand;

	public class SettingsViewModel : ViewModel
	{
		public SettingsViewModel()
		{
			ApplyAsyncCommand = new AsyncCommand(() => Task.Delay(1000));
		}

		public string ServerName
		{
			get => Get<string>();
			set => Set(value);
		}

		public ICommand ApplyAsyncCommand { get; }
	}
}