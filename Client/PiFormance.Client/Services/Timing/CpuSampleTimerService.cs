namespace PiFormance.Client.Services.Timing
{
	using Core.Standard.ArgumentMust;
	using Messengers;
	using Messengers.Messages;

	public class CpuSampleTimerService
	{
		private readonly SampleMessenger _sampleMessenger;

		public CpuSampleTimerService(SampleMessenger sampleMessenger)
		{
			ArgumentMust.NotBeNull(() => sampleMessenger);

			_sampleMessenger = sampleMessenger;

			SetupTimer();
		}

		private void SetupTimer()
		{
			var timer = new System.Timers.Timer(1200)
			{
				AutoReset = true
			};
			timer.Elapsed += (sender, args) => NotifyAboutUpcomingUpdate();
			timer.Start();
		}

		private void NotifyAboutUpcomingUpdate()
		{
			_sampleMessenger.Post(new SamplesShouldBeAcquired());
		}
	}
}