namespace PiFormance.Server.HardwareAccess.Wrappers
{
	using Core.Standard.ArgumentMust;
	using Core.Standard.Quantities.Definitions;
	using OpenHardwareMonitor.Hardware;

	public static class SensorExtensions
	{
		public static TQuantity GetSensorData<TQuantity, TUnit>(this ISensor sensor)
			where TQuantity : PhysicalQuantity<TQuantity>, new()
			where TUnit : Unit<TQuantity>, new()
		{
			ArgumentMust.NotBeNull(() => sensor);
			
			var quantity = new TQuantity();

			if (sensor.Value.HasValue)
			{
				quantity = quantity.In<TUnit>();
				quantity.Value = sensor.Value.Value;
			}

			return quantity;
		}
	}
}