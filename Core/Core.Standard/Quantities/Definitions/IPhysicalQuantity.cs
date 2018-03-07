namespace Core.Standard.Quantities.Definitions
{
	public interface IPhysicalQuantity<TPhysicalQuantity> : IPhysicalQuantityBase
		where TPhysicalQuantity : IPhysicalQuantity<TPhysicalQuantity>
	{
		Unit<TPhysicalQuantity> Unit { get; }
	}
}