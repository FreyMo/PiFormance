namespace Core.Standard.Quantities.LengthQuantity
{
	using System;
	using Definitions;

	[Serializable]
	public sealed class NanoMeter : Unit<Length>
	{
		public static NanoMeter Instance { get; } = new NanoMeter();

		public override string Symbol => "nm";

		public override double FactorToBaseUnit => 1.0e-9;
	}
}