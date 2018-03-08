namespace Core.Standard.Quantities.LengthQuantity
{
	using System;
	using Definitions;

	[Serializable]
	public sealed class Inch : Unit<Length>
	{
		public static Inch Instance { get; } = new Inch();

		public override string Symbol => "in";

		public override double FactorToBaseUnit => 1.0e-3 * 25.4;
	}
}