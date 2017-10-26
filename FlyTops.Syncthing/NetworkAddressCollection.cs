using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FlyTops.Syncthing
{
    [DataContract]
    public class NetworkAddressCollection
    {
        [DataMember(Name = "lanAddresses")]
        public List<Uri> Lan { get; set; }

        [DataMember(Name = "wanAddresses")]
        public List<Uri> Wan { get; set; }
    }
}
