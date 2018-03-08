namespace Core.Standard.Quantities.Definitions
{
	using System;

	[Serializable]
	public abstract class Unit<TPhysicalQuantity> : IUnitBase
		where TPhysicalQuantity : IPhysicalQuantity<TPhysicalQuantity>
	{
		public abstract double FactorToBaseUnit { get; }

		public abstract string Symbol { get; }
	}
}