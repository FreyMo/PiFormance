﻿namespace Core.Standard.Quantities.RatioQuantity
{
	using System;
	using Definitions;

	[Serializable]
	public class Ratio : PhysicalQuantity<Ratio>
	{
		public Ratio() : this(default(double))
		{
		}

		public Ratio(double value) : base(value, Whole.Instance)
		{
		}

		public Ratio(double value, Unit<Ratio> unit) : base(value, unit)
		{
		}

		public override BaseUnit<Ratio> BaseUnit => Whole.Instance;
	}
}