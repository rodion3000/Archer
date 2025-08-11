using Project.Data.StageData;
using UnityEngine;
using Zenject;

namespace Project.Dev.GamePlay.Location
{
    public class LocationManager : MonoBehaviour
    {
        [SerializeField] private StageLocalData _stageLocalData;

        [Inject]
        private void Construct(StageLocalData stageLocalData)
        {
            _stageLocalData = stageLocalData;
        }

        public void InitializeData(out StageLocalData localData)
        {
            localData = _stageLocalData;
        }

    }
}
