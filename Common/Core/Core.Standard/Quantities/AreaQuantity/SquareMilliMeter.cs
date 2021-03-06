namespace Core.Standard.Quantities.AreaQuantity
{
	using System;
	using Definitions;

	[Serializable]
	public sealed class SquareMilliMeter : Unit<Area>
	{
		public static SquareMilliMeter Instance { get; } = new SquareMilliMeter();

		public override string Symbol => "mm�";

		public override double FactorToBaseUnit => 1.0e-6;
	}
}