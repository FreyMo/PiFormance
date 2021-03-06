﻿namespace Core.Standard.Quantities.IntensityQuantity
{
	using System;
	using Definitions;

	[Serializable]
	public class WattPerSquareCentimeter : Unit<Intensity>
	{
		public static WattPerSquareCentimeter Instance { get; } = new WattPerSquareCentimeter();

		public override string Symbol => "W/cm²";

		public override double FactorToBaseUnit => 1.0e4;
	}
}