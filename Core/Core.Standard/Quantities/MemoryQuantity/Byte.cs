namespace Core.Standard.Quantities.MemoryQuantity
{
	using System;
	using Definitions;

	[Serializable]
	public sealed class Byte : BaseUnit<Memory>
	{
		public static Byte Instance { get; } = new Byte();

		public override string Symbol => "B";
	}
}