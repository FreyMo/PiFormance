﻿namespace Core.Standard.Quantities.RatioQuantity
{
	using System;
	using Definitions;

	[Serializable]
	public class Percent : Unit<Ratio>
	{
		public static Percent Instance { get; } = new Percent();

		public override string Symbol => "%";

		public override double FactorToBaseUnit => 1.0e-2;
	}
}