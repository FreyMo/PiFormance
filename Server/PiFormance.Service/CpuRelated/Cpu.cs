﻿namespace PiFormance.Services.CpuRelated
{
	using System.Collections.Generic;
	using System.Runtime.Serialization;
	using global::Core.Common.ArgumentMust;
	using global::Core.Common.Quantities.FrequencyQuantity;

	[DataContract]
	public class Cpu
	{
		public Cpu(Frequency clockSpeed, IEnumerable<Core> cores)
		{
			ArgumentMust.NotBeNull(() => clockSpeed);
			ArgumentMust.NotBeNullOrEmpty(() => cores);

			Cores = cores;
		}
		
		[DataMember]
		public Frequency ClockSpeed { get; private set; }

		[DataMember]
		public IEnumerable<Core> Cores { get; private set; }
	}
}