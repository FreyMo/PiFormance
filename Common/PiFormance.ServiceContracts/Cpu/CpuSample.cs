namespace PiFormance.ServiceContracts.Cpu
{
	using System.Collections.Generic;
	using System.Runtime.Serialization;
	using Core.Standard.ArgumentMust;
	using Core.Standard.Quantities.FrequencyQuantity;
	using Core.Standard.Quantities.TemperatureQuantity;

	[DataContract]
	[KnownType(typeof(KiloHertz))]
	[KnownType(typeof(MegaHertz))]
	[KnownType(typeof(GigaHertz))]
	[KnownType(typeof(Celsius))]
	public class CpuSample
	{
		public CpuSample(
			string name,
			Frequency clockSpeed,
			Frequency busSpeed,
			TotalUsage totalUsage,
			Temperature packageTemperature,
			IEnumerable<LogicalCore> cores,
			IEnumerable<Temperature> temperatures)
		{
			ArgumentMust.NotBeNullOrWhitespace(() => name);
			ArgumentMust.NotBeNull(() => clockSpeed);
			ArgumentMust.NotBeNull(() => busSpeed);
			ArgumentMust.NotBeNull(() => totalUsage);
			ArgumentMust.NotBeNull(() => packageTemperature);
			ArgumentMust.NotBeNullOrEmpty(() => cores);
			ArgumentMust.NotBeNullOrEmpty(() => temperatures);

			Name = name;
			ClockSpeed = clockSpeed;
			BusSpeed = busSpeed;
			TotalUsage = totalUsage;
			PackageTemperature = packageTemperature;
			Cores = cores;
			Temperatures = temperatures;
		}

		[DataMember]
		public string Name { get; private set; }

		[DataMember]
		public Frequency ClockSpeed { get; private set; }

		[DataMember]
		public Frequency BusSpeed { get; private set; }

		[DataMember]
		public TotalUsage TotalUsage { get; private set; }

		[DataMember]
		public Temperature PackageTemperature { get; private set; }

		[DataMember]
		public IEnumerable<LogicalCore> Cores { get; private set; }

		[DataMember]
		public IEnumerable<Temperature> Temperatures { get; private set; }
	}
}