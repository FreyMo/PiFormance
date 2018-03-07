namespace Core.Standard.Quantities.PowerQuantity
{
	using System;
	using Definitions;

	[Serializable]
	public sealed class Watt : BaseUnit<Power>
	{
		public static Watt Instance { get; } = new Watt();

		public override string Symbol => "W";
	}
}