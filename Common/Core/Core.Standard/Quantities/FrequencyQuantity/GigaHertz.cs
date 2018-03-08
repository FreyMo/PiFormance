namespace Core.Standard.Quantities.FrequencyQuantity
{
	using System;
	using Definitions;

	[Serializable]
	public sealed class GigaHertz : Unit<Frequency>
	{
		public static GigaHertz Instance { get; } = new GigaHertz();

		public override string Symbol => "GHz";

		public override double FactorToBaseUnit => 1.0e9;
	}
}