namespace Core.Standard.Quantities.Definitions
{
	public interface IPhysicalQuantityBase
	{
		double Value { get; set; }

		string UnitSymbol { get; }
	}
}