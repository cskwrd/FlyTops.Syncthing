using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FlyTops.Syncthing
{
    [DataContract]
    public class VersioningParameter
    {
        [DataMember(Name = "key")]
        public string Key { get; set; }

        [DataMember(Name = "val")]
        public string Value { get; set; }
    }
}
