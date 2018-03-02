namespace PiFormance.Services.CpuRelated
{
	using System.Runtime.Serialization;
	using global::Core.Common.ArgumentMust;

	[DataContract]
	public class Core
	{
		public Core(int id, Clock clock, Temperature temperature, Load load)
		{
			ArgumentMust.NotBeNull(() => clock);
			ArgumentMust.NotBeNull(() => temperature);
			ArgumentMust.NotBeNull(() => load);

			Id = id;
			Clock = clock;
			Temperature = temperature;
			Load = load;
		}

		[DataMember]
		public int Id { get; private set; }

		[DataMember]
		public Clock Clock { get; private set; }

		[DataMember]
		public Temperature Temperature { get; private set; }

		[DataMember]
		public Load Load { get; private set; }
	}
}