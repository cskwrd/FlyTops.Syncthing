using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FlyTops.Syncthing
{
    [DataContract]
    public class Configuration
    {
        [DataMember(Name = "version")]
        public int ConfigVersion { get; set; }

        [DataMember(Name = "folders")]
        public List<Folder> Folders { get; set; }

        [DataMember(Name = "devices")]
        public List<Device> Devices { get; set; }

        [DataMember(Name = "gui")]
        public GuiOptions GuiOptions { get; set; }

        [DataMember(Name = "options")]
        public ClientOptions SyncthingOptions { get; set; }

        [DataMember(Name = "ignoredDevices")]
        public List<string> IgnoredDeviceIds { get; set; }

        [DataMember(Name = "ignoredFolders")]
        public List<string> IgnoredFolderIds { get; set; }
    }
}
