using System.Threading.Tasks;
using Project.Dev.Infrastructure.Factories.Interfaces;
using Project.Dev.Infrastructure.GameStateMachine.Interface;
using Project.Dev.Infrastructure.GameStateMachine.TaskExtensions;
using Project.Dev.Infrastructure.SceneManagment;

namespace Project.Dev.Infrastructure.GameStateMachine.States
{
    public class LoadMetaState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly IUIFactorie _uiFactorie;

        public LoadMetaState(GameStateMachine stateMachine, SceneLoader sceneLoader, IUIFactorie uiFactorie)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _uiFactorie = uiFactorie;
        }

        public void Enter()
        {
            WarmUpAndLoad().ProcessErrors();
        }
        private async Task WarmUpAndLoad()
        {
            var sceneInstance = _sceneLoader.Load(SceneName.Meta);
        }
        public void Exit()
        {
            
        }

        private async Task InitMainMenu()
        {
            var controller = await _uiFactorie.CreateMenu();
            await controller.Initialize();
        }

        
    }
}

