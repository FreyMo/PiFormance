﻿namespace Core.Standard.Quantities.MemoryQuantity
{
	using System;
	using Definitions;

	[Serializable]
	public class Memory : PhysicalQuantity<Memory>
	{
		public Memory() : this(default(double))
		{
		}

		public Memory(double value) : this(value, Byte.Instance)
		{
		}

		public Memory(double value, Unit<Memory> unit) : base(value, unit)
		{
		}

		public override BaseUnit<Memory> BaseUnit => Byte.Instance;
	}
}