namespace Core.Standard.Quantities.AreaQuantity
{
	using System;
	using Definitions;

	[Serializable]
	public sealed class SquareMeter : BaseUnit<Area>
	{
		public static SquareMeter Instance { get; } = new SquareMeter();

		public override string Symbol => "m²";
	}
}