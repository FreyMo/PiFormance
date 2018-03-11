namespace PiFormance.Client.Services.Messengers.Messages
{
	using Core.Standard.ArgumentMust;
	using ServiceContracts.Memory;

	public class RamSampleAcquired
	{
		public RamSampleAcquired(RamSample ramSample)
		{
			ArgumentMust.NotBeNull(() => ramSample);

			RamSample = ramSample;
		}

		public RamSample RamSample { get; }
	}
}