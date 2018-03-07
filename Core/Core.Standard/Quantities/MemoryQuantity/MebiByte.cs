﻿namespace Core.Standard.Quantities.MemoryQuantity
{
	using System;
	using Definitions;

	[Serializable]
	public sealed class MebiByte : Unit<Memory>
	{
		public static MebiByte Instance { get; } = new MebiByte();

		public override double FactorToBaseUnit => 1024 * 1024;

		public override string Symbol => "MiB";
	}
}