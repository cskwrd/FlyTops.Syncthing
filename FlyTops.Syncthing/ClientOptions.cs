using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FlyTops.Syncthing
{
    [DataContract]
    public class ClientOptions
    {
        [DataMember(Name = "listenAddress")]
        public string ListenAddress { get; set; }

        [DataMember(Name = "globalAnnounceServer")]
        public string GlobalAnnounceServer { get; set; }

        [DataMember(Name = "globalAnnounceEnabled")]
        public bool IsGlobalAnnounceEnabled { get; set; }

        [DataMember(Name = "localAnnounceEnabled")]
        public bool IsLocalAnnounceEnabled { get; set; }

        [DataMember(Name = "localAnnouncePort")]
        public int LocalAnnouncePort { get; set; }

        [DataMember(Name = "localAnnounceMCAddr")]
        public string LocalAnnounceMCAddr { get; set; }

        [DataMember(Name = "maxSendKbps")]
        public int MaxSendKbps { get; set; }

        [DataMember(Name = "maxRecvKbps")]
        public int MaxRecvKbps { get; set; }

        [DataMember(Name = "reconnectionIntervalS")]
        public int ReconnectionIntervalSseconds { get; set; }

        [DataMember(Name = "relaysEnabled")]
        public bool RelaysEnabled { get; set; }

        [DataMember(Name = "relayReconnectIntervalM")]
        public int RelayReconnectIntervalMinutes { get; set; }

        [DataMember(Name = "startBrowser")]
        public bool StartBrowser { get; set; }

        [DataMember(Name = "natEnabled")]
        public bool IsNatEnabled { get; set; }

        [DataMember(Name = "natLeaseMinutes")]
        public int NatLeaseMinutes { get; set; }

        [DataMember(Name = "natRenewalMinutes")]
        public int NatRenewalMinutes { get; set; }

        [DataMember(Name = "natTimeoutSeconds")]
        public int NatTimeoutSeconds { get; set; }

        [DataMember(Name = "urAccepted")]
        public int UrAccepted { get; set; }

        [DataMember(Name = "urUniqueID")]
        public string UrUniqueID { get; set; }

        [DataMember(Name = "urURL")]
        public string UrURL { get; set; }

        [DataMember(Name = "urPostInsecurely")]
        public bool CanUrPostInsecurely { get; set; }

        [DataMember(Name = "urInitialDelayS")]
        public int UrInitialDelaySeconds { get; set; }

        [DataMember(Name = "restartOnWakeup")]
        public bool RestartOnWakeup { get; set; }

        [DataMember(Name = "autoUpgradeIntervalH")]
        public int AutoUpgradeIntervalHours { get; set; }

        [DataMember(Name = "upgradeToPreReleases")]
        public bool CanUpgradeToPreReleases { get; set; }

        [DataMember(Name = "keepTemporariesH")]
        public int KeepTemporariesHours { get; set; }

        [DataMember(Name = "cacheIgnoredFiles")]
        public bool CanCacheIgnoredFiles { get; set; }

        [DataMember(Name = "progressUpdateIntervalS")]
        public int ProgressUpdateIntervalSeconds { get; set; }

        [DataMember(Name = "limitBandwidthInLan")]
        public bool LimitBandwidthInLan { get; set; }

        [DataMember(Name = "minHomeDiskFree")]
        public MinimumDiskSpace MinHomeDiskSpace { get; set; }

        [DataMember(Name = "releasesURL")]
        public string ReleasesURL { get; set; }

        [DataMember(Name = "overwriteRemoteDeviceNamesOnConnect")]
        public bool OverwriteRemoteDeviceNamesOnConnect { get; set; }

        [DataMember(Name = "tempIndexMinBlocks")]
        public int TempIndexMinBlocks { get; set; }

        [DataMember(Name = "trafficClass")]
        public int TrafficClass { get; set; }

        [DataMember(Name = "weakHashSelectionMethod")]
        public string WeakHashSelectionMethod { get; set; }

        [DataMember(Name = "stunServer")]
        public string StunServer { get; set; }

        [DataMember(Name = "stunKeepaliveSeconds")]
        public int StunKeepaliveSeconds { get; set; }

        [DataMember(Name = "defaultKCPEnabled")]
        public bool IsDefaultKCPEnabled { get; set; }

        [DataMember(Name = "kcpNoDelay")]
        public bool UseKcpNoDelay { get; set; }

        [DataMember(Name = "kcpUpdateIntervalMs")]
        public int KcpUpdateIntervalMilliseconds { get; set; }

        [DataMember(Name = "kcpFastResend")]
        public bool UseKcpFastResend { get; set; }

        [DataMember(Name = "kcpCongestionControl")]
        public bool IsKcpCongestionControl { get; set; }

        [DataMember(Name = "kcpSendWindowSize")]
        public int KcpSendWindowSize { get; set; }

        [DataMember(Name = "kcpReceiveWindowSize")]
        public int KcpReceiveWindowSize { get; set; }

        [DataMember(Name = "defaultFolderPath")]
        public string DefaultFolderPath { get; set; }

        [DataMember(Name = "minHomeDiskFreePct")]
        public int MinHomeDiskFreePct { get; set; }
    }
}
