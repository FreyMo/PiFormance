namespace Core.Standard.Quantities.FrequencyQuantity
{
	using System;
	using Definitions;

	[Serializable]
	public sealed class Hertz : BaseUnit<Frequency>
	{
		public static Hertz Instance { get; } = new Hertz();

		public override string Symbol => "Hz";
	}
}