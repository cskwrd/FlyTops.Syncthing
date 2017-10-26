using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FlyTops.Syncthing
{
    [DataContract]
    public class Folder
    {
        #region Attributes

        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "label")]
        public string Label { get; set; }

        [DataMember(Name = "path")]
        public string Path { get; set; }

        [DataMember(Name = "type")]
        public string Type { get; set; } // TODO: make enum value

        [DataMember(Name = "rescanIntervalS")]
        public int RescanIntervalSeconds { get; set; }

        [DataMember(Name = "ignorePerms")]
        public bool IgnorePermissions { get; set; }

        [DataMember(Name = "autoNormalize")]
        public bool AutomaticallyNormalize { get; set; }

        #endregion

        [DataMember(Name = "filesystemType")]
        public string FileSystemType { get; set; }

        [DataMember(Name = "device")]
        public List<Device> Devices { get; set; }

        [DataMember(Name = "minDiskFree")]
        public MinimumDiskSpace MinDiskSpace { get; set; }

        [DataMember(Name = "versioning")]
        public VersioningMethod Versioning { get; set; } // I think this indicates how the folder is versioned

        [DataMember(Name = "copiers")]
        public int Copiers { get; set; }

        [DataMember(Name = "pullers")]
        public int Pullers { get; set; }

        [DataMember(Name = "hashers")]
        public int Hashers { get; set; }

        [DataMember(Name = "order")]
        public string Order { get; set; } // TODO: make enum value

        [DataMember(Name = "ignoreDelete")]
        public bool IgnoreDelete { get; set; }

        [DataMember(Name = "scanProgressIntervalS")]
        public int ProgresScanIntervalSeconds { get; set; }

        [DataMember(Name = "pullerSleepS")]
        public int PullerSleepSeconds { get; set; }

        [DataMember(Name = "pullerPauseS")]
        public int PullerPauseSeconds { get; set; }

        [DataMember(Name = "maxConflicts")]
        public int MaxConflicts { get; set; }

        [DataMember(Name = "disableSparseFiles")]
        public bool SparseFilesDisabled { get; set; }

        [DataMember(Name = "disableTempIndexes")]
        public bool TempIndexesDisabled { get; set; }

        [DataMember(Name = "paused")]
        public bool IsPaused { get; set; }

        [DataMember(Name = "weakHashThresholdPct")]
        public int WeakHashThresholdPercent { get; set; }
    }
}
