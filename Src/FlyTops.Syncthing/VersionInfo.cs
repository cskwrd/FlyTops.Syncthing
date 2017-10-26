using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FlyTops.Syncthing
{
    [DataContract]
    public class VersionInfo
    {
        [DataMember(Name = "arch")]
        public string Architecture { get; set; }

        [DataMember(Name = "codename")]
        public string CodeName { get; set; }

        [DataMember(Name = "longVersion")]
        public string LongVersion { get; set; }

        [DataMember(Name = "os")]
        public string OperatingSystem { get; set; }

        [DataMember(Name = "version")]
        public string Version { get; set; }
    }
}
