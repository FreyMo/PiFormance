namespace Core.Standard.Quantities.MemoryQuantity
{
	using System;
	using Definitions;

	[Serializable]
	public sealed class KibiByte : Unit<Memory>
	{
		public static KibiByte Instance { get; } = new KibiByte();

		public override double FactorToBaseUnit => 1024;

		public override string Symbol => "KiB";
	}
}