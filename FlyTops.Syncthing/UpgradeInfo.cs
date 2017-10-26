using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FlyTops.Syncthing
{
    [DataContract]
    public class UpgradeInfo
    {
        [DataMember(Name = "latest")]
        public string LatestVersion { get; set; }

        [DataMember(Name = "newer")]
        public string IsUpdateAvailable { get; set; }

        [DataMember(Name = "running")]
        public string CurrentRunningVersion { get; set; }
    }
}
