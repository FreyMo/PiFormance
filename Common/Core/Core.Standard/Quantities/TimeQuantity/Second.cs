namespace Core.Standard.Quantities.TimeQuantity
{
	using System;
	using Definitions;

	[Serializable]
	public class Second : BaseUnit<Time>
	{
		public static Second Instance { get; } = new Second();

		public override string Symbol => "s";
	}
}