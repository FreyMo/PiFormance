namespace PiFormance.Client.ViewModels.Settings
{
	using System.Threading.Tasks;
	using System.Windows.Input;
	using Base;
	using Core.Standard.ArgumentMust;
	using Core.Standard.Commands.AsyncCommand;
	using Core.Standard.Extensions;
	using Core.Standard.Messenger.Messenger;
	using Services;
	using Services.Connection;
	using Services.Messengers;
	using Services.Messengers.Messages;

	public class SettingsViewModel : ViewModel, ISubscriberTo<ServerNameChanged>
	{
		private readonly ConnectionSettingsService _connectionSettingsService;
		private readonly ConnectionMessenger _messenger;

		public SettingsViewModel(ConnectionSettingsService connectionSettingsService, ConnectionMessenger messenger)
		{
			ArgumentMust.NotBeNull(() => connectionSettingsService);
			ArgumentMust.NotBeNull(() => messenger);

			_connectionSettingsService = connectionSettingsService;
			_messenger = messenger;
			_messenger.SubscribeTo(this);

			ServerName = _connectionSettingsService.ServerName.AsString;

			ApplyAsyncCommand = new AsyncCommand(ExecuteApplyCommandAsync);
		}

		public string ServerName
		{
			get => Get<string>();
			set => Set(value);
		}

		public ICommand ApplyAsyncCommand { get; }

		public void OnMessageReceived(ServerNameChanged message)
		{
			ArgumentMust.NotBeNull(() => message);

			ServerName = message.ServerName.AsString;
		}

		private async Task ExecuteApplyCommandAsync()
		{
			_connectionSettingsService.ReconnectTo(new ServerName(ServerName));

			await Task.Delay(500);
		}
	}
}