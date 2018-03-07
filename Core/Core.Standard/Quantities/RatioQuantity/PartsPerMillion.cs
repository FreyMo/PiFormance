namespace Core.Standard.Quantities.RatioQuantity
{
	using System;
	using Definitions;

	[Serializable]
	public class PartsPerMillion : Unit<Ratio>
	{
		public override string Symbol => "ppm";

		public override double FactorToBaseUnit => 1.0e-6;
	}
}