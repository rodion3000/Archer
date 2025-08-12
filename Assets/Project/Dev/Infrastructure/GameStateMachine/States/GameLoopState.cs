using Project.Dev.Infrastructure.Factories;
using Project.Dev.Infrastructure.GameStateMachine.Interface;
using Project.Dev.Services.LevelProgress;

namespace Project.Dev.Infrastructure.GameStateMachine.States
{
    public class GameLoopState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly HeroFactorie _heroFactorie;
        private readonly ILevelProgressService _levelProgressService;

        public GameLoopState(GameStateMachine stateMachine,
            HeroFactorie heroFactorie,
            ILevelProgressService levelProgressService)
        {
            _stateMachine = stateMachine;
            _heroFactorie = heroFactorie;
            _levelProgressService = levelProgressService;
        }
        public void Enter()
        {
            _levelProgressService.levelProgressWather.RunLvl();
        }

        public void Exit()
        {
            _heroFactorie.CleanUp();

        }
    }
}

