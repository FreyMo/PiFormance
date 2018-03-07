namespace Core.Standard.Quantities.LengthQuantity
{
	using System;
	using Definitions;

	[Serializable]
	public sealed class Meter : BaseUnit<Length>
	{
		public static Meter Instance { get; } = new Meter();

		public override string Symbol => "m";
	}
}