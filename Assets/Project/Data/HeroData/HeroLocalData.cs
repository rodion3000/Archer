using UnityEngine;

namespace Project.Data.HeroLocalData
{
    [CreateAssetMenu(fileName = "HeroLocalData", menuName = "Configs/HeroConfig/Hero Local Data")]

    public class HeroLocalData : ScriptableObject
    {
        [field: SerializeField] public float arrowSpeed { get; private set; } // Скорость полета стрелы
        [field: SerializeField] public float tiltSpeed { get; private set; } // Скорость наклона
        [field: SerializeField] public float maxTiltAngle { get; private set; } // Максимальный угол наклона
    }
}
