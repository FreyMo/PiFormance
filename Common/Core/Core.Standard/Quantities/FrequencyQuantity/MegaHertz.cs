namespace Core.Standard.Quantities.FrequencyQuantity
{
	using System;
	using Definitions;

	[Serializable]
	public sealed class MegaHertz : Unit<Frequency>
	{
		public static MegaHertz Instance { get; } = new MegaHertz();

		public override string Symbol => "MHz";

		public override double FactorToBaseUnit => 1.0e6;
	}
}