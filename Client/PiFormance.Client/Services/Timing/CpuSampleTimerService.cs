﻿namespace PiFormance.Client.Services.Timing
{
	using System;
	using Connection;
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
			timer.Elapsed += (sender, args) => HandleTimer();
			timer.Start();
		}

		private void HandleTimer()
		{
			_cpuSampleMessenger.Post(new CpuSampleShouldBeAcquired());
			_cpuSampleMessenger.Post(new RamSampleShouldBeAcquired());
		}
	}
}