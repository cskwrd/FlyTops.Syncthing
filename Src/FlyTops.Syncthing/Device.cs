using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FlyTops.Syncthing
{
    [DataContract]
    public class Device
    {
        #region Attributes

        [DataMember(Name = "id")]
        public string DeviceId { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "compression")]
        public string Compression { get; set; } // TODO: make this an enum

        [DataMember(Name = "introducer")]
        public bool IsIntroducer { get; set; }

        [DataMember(Name = "skipIntroductionRemovals")]
        public bool SkipIntroductionRemovals { get; set; }

        [DataMember(Name = "introducedBy")]
        public string IntroducedBy { get; set; }

        #endregion

        [DataMember(Name = "address")]
        public string Address { get; set; }

        [DataMember(Name = "paused")]
        public bool IsPaused { get; set; }
    }
}
