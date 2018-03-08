namespace PiFormance.Client.Connection
{
	using System;
	using System.ServiceModel;
	using System.Threading.Tasks;
	using Windows.ApplicationModel.Core;
	using Windows.System.Threading;
	using Windows.UI.Core;

	public abstract class ClientBase<TService> : IClient<TService>
		where TService : class
	{
		public event EventHandler<ConnectionChangedEventArgs> ConnectionChanged;

		private static readonly TimeSpan ReconnectDelay = TimeSpan.FromMilliseconds(2000);
		
		private bool _isConnected;
		
		protected ClientBase<TService> Client;
		
		public bool IsConnected
		{
			get => _isConnected;
			private set
			{
				if (_isConnected != value)
				{
					_isConnected = value;
					OnConnectionChanged();
				}
			}
		}

		protected ClientBase()
		{
			SetupServiceClientBase();
			Connect();
		}

		protected Task<T> SecureAsyncCall<T>(Func<Task<T>> func)
		{
			if (IsConnected)
			{
				return func.Invoke();
			}
			else
			{
				return new Task<T>(() => default(T));
			}
		}
		protected Task SecureAsyncCall(Func<Task> func)
		{
			if (IsConnected)
			{
				return func.Invoke();
			}
			else
			{
				return Task.CompletedTask;
			}
		}

		protected abstract void SetupServiceClient();

		protected abstract void RegisterCallbackHandlers();

		private void SetupServiceClientBase()
		{
			SetupServiceClient();
			ConfigureConnection();
			RegisterConnectionEventHandlers();
			RegisterCallbackHandlers();
		}

		private void ConfigureConnection()
		{
			// TODO
		}

		private void RegisterConnectionEventHandlers()
		{
			Client.InnerChannel.Opened += ServiceOpenedEventHandler;
			Client.InnerChannel.Closed += ServiceClosedEventHandler;
			Client.InnerChannel.Faulted += ServiceFaultedEventHandler;
		}

		protected void Connect()
		{
			if (!IsConnected)
			{
				try
				{
					Client.InnerChannel.Open();
				}
				catch (EndpointNotFoundException)
				{
					// TODO
				}
				finally
				{
					EvaluateConnection();
				}
			}
		}

		private void Reconnect()
		{
			ThreadPoolTimer.CreateTimer(
				async source =>
				{
					await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
						CoreDispatcherPriority.High,
						Connect);
				},
				ReconnectDelay);
		}

		private void OnConnectionChanged()
		{
			if (!IsConnected)
			{
				EvaluateConnection();
			}

			ConnectionChanged?.Invoke(this, new ConnectionChangedEventArgs(IsConnected));
		}

		private void EvaluateConnection()
		{
			IsConnected = Client.State == CommunicationState.Opened;

			if (!IsConnected)
			{
				Reconnect();
			}
		}
		
		private void ServiceOpenedEventHandler(object sender, EventArgs e)
		{
			EvaluateConnection();
		}

		private void ServiceClosedEventHandler(object sender, EventArgs e)
		{
			EvaluateConnection();
		}

		private void ServiceFaultedEventHandler(object sender, EventArgs e)
		{
			SetupServiceClientBase();
			EvaluateConnection();
		}
	}
}
