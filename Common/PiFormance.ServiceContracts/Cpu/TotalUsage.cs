using System;
using System.Collections.Generic;
using System.Text;

namespace PiFormance.ServiceContracts.Cpu
{
	using System.Runtime.Serialization;
	using Core.Standard.Quantities.RatioQuantity;

	[DataContract]
	public class TotalUsage : CpuPart
    {
	    public TotalUsage(Ratio load) : base(load)
	    {
	    }
    }
}