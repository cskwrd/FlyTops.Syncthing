using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FlyTops.Syncthing
{
    [DataContract]
    public class ConnectionInfo
    {
        [DataMember(Name = "paused")]
        public bool IsPaused { get; set; }

        [DataMember(Name = "clientVersion")]
        public string CiientVersion { get; set; }

        [DataMember(Name = "connected")]
        public bool IsConnected { get; set; }

        [DataMember(Name = "inBytesTotal")]
        public long TotalRxBytes { get; set; }

        [DataMember(Name = "type")]
        public string ConnectionType { get; set; } // TODO: make enum, see https://docs.syncthing.net/rest/system-connections-get.html

        [DataMember(Name = "outBytesTotal")]
        public long TotalTxBytes { get; set; }

        [DataMember(Name = "address")]
        public string Address { get; set; }
    }
}
