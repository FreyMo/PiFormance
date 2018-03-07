namespace Core.Standard.Quantities.Definitions
{
	public interface IPhysicalQuantityBase
	{
		double Value { get; }

		string UnitSymbol { get; }
	}
}