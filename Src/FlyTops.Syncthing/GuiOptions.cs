using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FlyTops.Syncthing
{
    [DataContract]
    public class GuiOptions
    {
        [DataMember(Name = "enabled")]
        public bool IsEnabled { get; set; }

        [DataMember(Name = "address")]
        public string Address { get; set; }

        [DataMember(Name = "user")]
        public string Username { get; set; }

        [DataMember(Name = "password")]
        public string Password { get; set; }

        [DataMember(Name = "useTLS")]
        public string UseTls { get; set; }

        [DataMember(Name = "apiKey")]
        public string ApiKey { get; set; }

        [DataMember(Name = "insecureAdminAccess")]
        public bool IsInsecureAdminAccessAllowed { get; set; }

        [DataMember(Name = "theme")]
        public string SelectedTheme { get; set; }

        [DataMember(Name = "debugging")]
        public bool IsDebugMode { get; set; }

        [DataMember(Name = "insecureSkipHostcheck")]
        public bool IsInsecureSkipHostCheckAllowed { get; set; }

        [DataMember(Name = "insecureAllowFrameLoading")]
        public bool IsInsecureFrameLoadingAllowed { get; set; }
    }
}
