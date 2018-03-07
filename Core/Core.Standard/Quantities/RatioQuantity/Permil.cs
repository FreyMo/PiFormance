namespace Core.Standard.Quantities.RatioQuantity
{
	using System;
	using Definitions;

	[Serializable]
	public class Permil : Unit<Ratio>
	{
		public override string Symbol => "‰";

		public override double FactorToBaseUnit => 1.0e-3;
	}
}