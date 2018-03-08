namespace Core.Standard.Quantities.MemoryQuantity
{
	using System;
	using Definitions;

	[Serializable]
	public sealed class GibiByte : Unit<Memory>
	{
		public static GibiByte Instance { get; } = new GibiByte();

		public override double FactorToBaseUnit => 1024 * 1024 * 1024;

		public override string Symbol => "GiB";
	}
}