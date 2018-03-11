namespace PiFormance.Client.Services.Timing
{
	using Core.Standard.ArgumentMust;
	using Messengers;
	using Messengers.Messages;

	public class CpuSampleTimerService
	{
		private readonly CpuSampleMessenger _cpuSampleMessenger;

		public CpuSampleTimerService(CpuSampleMessenger cpuSampleMessenger)
		{
			ArgumentMust.NotBeNull(() => cpuSampleMessenger);

			_cpuSampleMessenger = cpuSampleMessenger;

			SetupTimer();
		}

		private void SetupTimer()
		{
			var timer = new System.Timers.Timer(1000)
			{
				AutoReset = true
			};
			timer.Elapsed += (sender, args) => NotifyAboutUpcomingUpdate();
			timer.Start();
		}

		private void NotifyAboutUpcomingUpdate()
		{
			_cpuSampleMessenger.Post(new CpuSampleShouldBeAcquired());
			_cpuSampleMessenger.Post(new RamSampleShouldBeAcquired());
		}
	}
}