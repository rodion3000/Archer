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
           _ = WarmUpAndLoad().ProcessErrors();
        }
        private async Task WarmUpAndLoad()
        {
            await _uiFactorie.WarmUp();
            var sceneInstance = _sceneLoader.Load(SceneName.Meta);
            await InitUiRoot();
            await InitMainMenu();
        }
        public void Exit()
        {
            _uiFactorie.CleanUp();
        }

        private async Task InitUiRoot() =>
            await _uiFactorie.CreateUiRoot();

        private async Task InitMainMenu()
        {
            var controller = await _uiFactorie.CreateMenu();
            await controller.Initialize();
        }

        
    }
}

