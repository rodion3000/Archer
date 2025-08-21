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
        [SerializeField] private Button returnButton;
        private GameStateMachine _stateMachine;
        //private StageLocalData localData;
        private LocationManager _locationManager;
        
        [Inject]
        private void Construct(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Initialize()
        {
            NextLvlButtonClicked();
            ReturnsButtonClicked();
        }
        private void NextLvlButtonClicked()
        {
            nextLvlButton.onClick.AddListener((() => 
            {
                _locationManager.InitializeData(out StageLocalData gh);
                _stateMachine.Enter<LoadLevelState, StageLocalData>(gh);
            }));
        }

        private void ReturnsButtonClicked() =>
            returnButton.onClick.AddListener(() =>
                _stateMachine.Enter<LoadMetaState>());

    }
}
