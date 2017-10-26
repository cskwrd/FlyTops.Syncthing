using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FlyTops.Syncthing
{
    [DataContract]
    public class ConnectionSummary
    {
        [DataMember(Name = "total")]
        public ConnectionInfo Total { get; set; }

        [DataMember(Name = "connections")]
        public Dictionary<string, ConnectionInfo> Connections { get; set; }
    }
}
