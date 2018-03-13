namespace PiFormance.Server.HardwareAccess.Wrappers
{
	using Core.Standard.Quantities.Definitions;
	using OpenHardwareMonitor.Hardware;

	public static class SensorExtensions
	{
		public static TQuantity GetSensorData<TQuantity, TUnit>(this ISensor sensor)
			where TQuantity : PhysicalQuantity<TQuantity>, new()
			where TUnit : Unit<TQuantity>, new()
		{
			var quantity = new TQuantity().In<TUnit>();

			if (sensor == null)
			{
				return quantity;
			}

			if (sensor.Value.HasValue)
			{
				quantity.Value = sensor.Value.Value;
			}

			return quantity;
		}
	}
}