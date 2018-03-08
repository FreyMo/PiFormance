namespace Core.Standard.Quantities.RatioQuantity
{
	using System;
	using Definitions;

	[Serializable]
	public class Whole : BaseUnit<Ratio>
	{
		public static Whole Instance { get; } = new Whole();

		public override string Symbol => string.Empty;
	}
}