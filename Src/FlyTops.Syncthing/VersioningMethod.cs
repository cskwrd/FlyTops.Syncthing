using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FlyTops.Syncthing
{
    [DataContract]
    public class VersioningMethod
    {
        [DataMember(Name = "type")]
        public string Method { get; set; }

        [DataMember(Name = "param")]
        public List<VersioningParameter> Parameters { get; set; }
    }
}
