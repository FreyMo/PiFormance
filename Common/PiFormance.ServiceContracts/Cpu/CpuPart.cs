namespace PiFormance.ServiceContracts.Cpu
{
	using System.Runtime.Serialization;
	using Core.Standard.ArgumentMust;
	using Core.Standard.Quantities.RatioQuantity;

	[DataContract]
	[KnownType(typeof(Percent))]
	public class CpuPart
	{
		public CpuPart(Ratio load)
		{
			ArgumentMust.NotBeNull(() => load);

			Load = load;
		}

		[DataMember]
		public Ratio Load { get; private set; }
	}
}