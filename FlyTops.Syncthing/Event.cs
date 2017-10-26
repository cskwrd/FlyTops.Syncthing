using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FlyTops.Syncthing
{
    [DataContract]
    public class Event
    {
        [DataMember(Name = "when")]
        public DateTime OccurredAt { get; set; }

        [DataMember(Name = "message")]
        public string Message { get; set; }
    }
}
