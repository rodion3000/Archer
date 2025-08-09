using System.Threading.Tasks;
using Project.Dev.Infrastructure.GameStateMachine.Interface;
using Project.Dev.Infrastructure.GameStateMachine.TaskExtensions;
using Project.Dev.Infrastructure.SceneManagment;

namespace Project.Dev.Infrastructure.GameStateMachine.States
{
    public class LoadMetaState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;

        public LoadMetaState(GameStateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
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

        
    }
}

