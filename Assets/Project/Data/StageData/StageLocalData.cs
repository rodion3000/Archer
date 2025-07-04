using System;
using UnityEngine;

namespace Project.Data.StageData
{

    [Serializable]
    public record StageLocalData
    {
        public string LocationName { get;  set; }
        public Vector3 PlayerSpawnPoint { get;  set; }
        public TransitLocationData[] TransitSpawnPoint { get; set; }
    }
}
