﻿namespace Core.Standard.Quantities.TimeQuantity
{
	using System;
	using Definitions;

	[Serializable]
	public class NanoSecond : Unit<Time>
	{
		public static NanoSecond Instance { get; } = new NanoSecond();

		public override string Symbol => "ns";

		public override double FactorToBaseUnit => 1.0e-9;
	}
}