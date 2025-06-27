using UnityEngine;

namespace Project.Data.StageData
{
    [CreateAssetMenu(fileName = "StageLocalData", menuName = "Configs/LocalDataConfig/Stage Local Data")]

    public class StageLocalData : ScriptableObject
    {
        [field: SerializeField] public string StageKey { get; private set; }
        [field: SerializeField] public Transform PlayerSpawnPoint { get; private set; }
    }
}
