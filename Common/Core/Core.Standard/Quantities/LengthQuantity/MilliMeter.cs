namespace Core.Standard.Quantities.LengthQuantity
{
	using System;
	using Definitions;

	[Serializable]
	public sealed class MilliMeter : Unit<Length>
	{
		public static MilliMeter Instance { get; } = new MilliMeter();

		public override string Symbol => "mm";

		public override double FactorToBaseUnit => 1.0e-3;
	}
}