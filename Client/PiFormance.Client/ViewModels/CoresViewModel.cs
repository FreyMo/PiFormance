namespace PiFormance.Client.ViewModels
{
	using System.Collections.ObjectModel;
	using System.Linq;
	using Base;
	using Core.Standard.ArgumentMust;
	using Core.Standard.Extensions;
	using Core.Standard.Messenger.Messenger;
	using Core.Standard.Quantities.RatioQuantity;
	using ServiceContracts.Cpu;
	using Services.Cpu;
	using Services.Messengers;
	using Services.Messengers.Messages;

	public class CoresViewModel : ViewModel, ISubscriberTo<CpuSampleAcquired>
	{
		public CoresViewModel(CpuSampleMessenger messenger, CpuSampleProviderService sampleProviderService)
		{
			ArgumentMust.NotBeNull(() => messenger);

			messenger.SubscribeTo(this);

			sampleProviderService.OnMessageReceived(new CpuSampleShouldBeAcquired());
		}

		public ObservableCollection<LogicalCore> Cores { get; } = new ObservableCollection<LogicalCore>();

		public void OnMessageReceived(CpuSampleAcquired message)
		{
			var cpuSample = message.CpuSample;

			if (Cores.IsEmpty())
			{
				foreach (var core in cpuSample.Cores)
				{
					Cores.Add(core);
				}
			}
			else
			{
				foreach (var newCore in cpuSample.Cores.Select((v, i) => new {core = v, index = i}))
				{
					var val = newCore.core.Load.In<Percent>().Value;
					Cores.ElementAt(newCore.index).Load.Value = newCore.core.Load.In<Percent>().Value;
				}
			}
		}
	}
}