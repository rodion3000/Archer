using Project.Data.StageData;
using Project.Dev.GamePlay.Location;
using Project.Dev.Infrastructure.GameStateMachine.States;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Project.Dev.Meta.UI.HudController
{
    public class HudController : MonoBehaviour
    {
        [SerializeField] private Button nextLvlButton;
        private GameStateMachine _stateMachine;
        private StageLocalData localData;
        private LocationManager _locationManager;
        
        [Inject]
        private void Construct(GameStateMachine stateMachine, LocationManager locationManager)
        {
            _stateMachine = stateMachine;
            _locationManager = locationManager;
        }
        
        private void NextLvlButtonClicked()
        {
            nextLvlButton.onClick.AddListener((() => 
            {
                _locationManager.InitializeData(out localData);
                _stateMachine.Enter<LoadLevelState, StageLocalData>(localData);
            }));
        }

    }
}
