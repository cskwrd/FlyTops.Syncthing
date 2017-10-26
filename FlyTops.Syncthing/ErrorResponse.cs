using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FlyTops.Syncthing
{
    [DataContract]
    public class ErrorResponse
    {
        [DataMember(Name = "errors")]
        public List<Event> ErrorList { get; set; }
    }
}
