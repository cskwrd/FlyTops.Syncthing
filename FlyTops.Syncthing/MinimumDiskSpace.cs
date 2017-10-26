using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FlyTops.Syncthing
{
    [DataContract]
    public class MinimumDiskSpace
    {
        [DataMember(Name = "unit")]
        public string MeasuredUnit { get; set; }

        [DataMember(Name = "value")]
        public int Value { get; set; }
    }
}
