namespace PiFormance.Services.CpuRelated
{
	using System.Runtime.Serialization;
	using global::Core.Common.Quantities.Definitions;
	using global::Core.Common.Quantities.RatioQuantity;

	[KnownType(typeof(Percent))]
	[KnownType(typeof(Whole))]
	[DataContract]
	public class Load : Ratio
	{
		public Load(double value, Unit<Ratio> unit) : base(value, unit)
		{
		}
	}
}