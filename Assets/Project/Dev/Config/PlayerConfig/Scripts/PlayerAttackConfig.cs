
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerAttackConfig", menuName = "Configs/PlayerConfig/Player Attack Config")]
public class PlayerAttackConfig : ScriptableObject
{
    [field: SerializeField] public GameObject player {get; private set;}
    [field: SerializeField] public GameObject arrowPrefab { get; private set; } // Префаб стрелы
    [field: SerializeField] public float arrowSpeed { get; private set; } // Скорость полета стрелы
    [field: SerializeField] public float tiltSpeed { get; private set; } // Скорость наклона
    [field: SerializeField] public GameObject stringObject { get; private set; }
    [field: SerializeField] public float maxTiltAngle { get; private set; } // Максимальный угол наклона
}
