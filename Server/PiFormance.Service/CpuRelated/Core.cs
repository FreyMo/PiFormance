namespace PiFormance.Services.CpuRelated
{
	using System.Runtime.Serialization;
	using global::Core.Common.ArgumentMust;
	using global::Core.Common.Quantities.RatioQuantity;

	[DataContract]
	public class Core
	{
		public Core(int id, Temperature temperature, Load load)
		{
			ArgumentMust.NotBeNull(() => temperature);
			ArgumentMust.NotBeNull(() => load);

			Id = id;
			Temperature = temperature;
			Load = load;
		}

		[DataMember]
		public int Id { get; private set; }

		[DataMember]
		public Temperature Temperature { get; private set; }

		[DataMember]
		public Load Load { get; private set; }
	}
}