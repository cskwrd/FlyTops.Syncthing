using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FlyTops.Syncthing
{
    [DataContract]
    public class LogResponse
    {
        [DataMember(Name = "messages")]
        public List<Event> LogEntries { get; set; }
    }
}
