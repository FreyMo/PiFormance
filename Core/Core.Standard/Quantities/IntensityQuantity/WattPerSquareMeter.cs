namespace Core.Standard.Quantities.IntensityQuantity
{
	using System;
	using Definitions;

	[Serializable]
	public class WattPerSquareMeter : BaseUnit<Intensity>
	{
		public static WattPerSquareMeter Instance { get; } = new WattPerSquareMeter();

		public override string Symbol => "W/m²";
	}
}