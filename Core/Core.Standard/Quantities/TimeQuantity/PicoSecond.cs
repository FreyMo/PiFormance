namespace Core.Standard.Quantities.TimeQuantity
{
	using System;
	using Definitions;

	[Serializable]
	public class PicoSecond : Unit<Time>
	{
		public static PicoSecond Instance { get; } = new PicoSecond();

		public override string Symbol => "ps";

		public override double FactorToBaseUnit => 1.0e-12;
	}
}