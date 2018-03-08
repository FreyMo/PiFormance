namespace PiFormance.Client
{
	using System;
	using System.Collections.ObjectModel;
	using System.Linq;
	using System.Threading;
	using System.Timers;
	using Connection;
	using Core.Standard.Extensions;
	using Core.Standard.Quantities.RatioQuantity;
	using ServiceContracts.Cpu;

	public class MainPageViewModel
	{
		private readonly SystemClient _client;
		private readonly SynchronizationContext _uiContext = SynchronizationContext.Current;

		public MainPageViewModel()
		{
			try
			{
				_client = new SystemClient();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}

			SetupTimer();
		}

		public ObservableCollection<LogicalCore> Cores { get; } = new ObservableCollection<LogicalCore>();

		private void SetupTimer()
		{
			var timer = new System.Timers.Timer(1000)
			{
				AutoReset = true
			};
			timer.Elapsed += (sender, args) => HandleTimer();
			timer.Start();
		}

		private async void HandleTimer()
		{
			var cpuSample = await _client.GetCpuSampleAsync();
			var ramSample = await _client.GetRamSampleAsync();

			_uiContext.Post(
				_ =>
				{
					if (Cores.IsEmpty())
					{
						foreach (var core in cpuSample.Cores)
						{
							Cores.Add(core);
						}
					}
					else
					{
						foreach (var newCore in cpuSample.Cores.Select((v, i) => new { core = v, index = i }))
						{
							Cores.ElementAt(newCore.index).Load.Value = newCore.core.Load.In<Percent>().Value;
						}
					}
				}, null);
		}
	}
}