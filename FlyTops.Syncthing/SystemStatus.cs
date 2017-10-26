using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FlyTops.Syncthing
{
    [DataContract]
    public class SystemStatus
    {
        [DataMember(Name = "alloc")]
        public long Alloc { get; set; }

        [DataMember(Name = "connectionServiceStatus")]
        public Dictionary<string, NetworkAddressCollection> ConnectionServiceStatusCollection { get; set; }

        [DataMember(Name = "cpuPercent")]
        public double CpuPercent { get; set; }

        [DataMember(Name = "discoveryEnabled")]
        public bool IsDiscoveryEnabled { get; set; }

        [DataMember(Name = "discoveryErrors")]
        public Dictionary<string, string> DiscoveryErrors { get; set; }

        [DataMember(Name = "discoveryMethods")]
        public int DiscoveryMethods { get; set; }

        [DataMember(Name = "goroutines")]
        public int GoRoutines { get; set; }

        [DataMember(Name = "myID")]
        public string ID { get; set; }

        [DataMember(Name = "pathSeparator")]
        public string PathSeparator { get; set; }

        [DataMember(Name = "startTime")]
        public DateTime StartTime { get; set; }

        [DataMember(Name = "sys")]
        public long Sys { get; set; }

        [DataMember(Name = "themes")]
        public List<string> Themes { get; set; }

        [DataMember(Name = "tilde")]
        public string TildeExpansionPath { get; set; }

        [DataMember(Name = "uptime")]
        public long Uptime { get; set; }
    }
}
