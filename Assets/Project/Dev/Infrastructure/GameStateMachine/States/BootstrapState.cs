using System.Collections.Generic;
using Project.Dev.Infrastructure.GameStateMachine.Interface;
using Project.Dev.Services.Interfaces;
using System.Threading.Tasks;
using Project.Dev.Infrastructure.GameStateMachine.TaskExtensions;
using Project.Dev.Services.Logging;

namespace Project.Dev.Infrastructure.GameStateMachine.States
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly List<IInitializableAsync> _initializableServices;
        private readonly LoggingService _loggingService;

        public BootstrapState(GameStateMachine stateMachine, List<IInitializableAsync> initializableServices, LoggingService loggingService)
        {
            _stateMachine = stateMachine;
            _initializableServices = initializableServices;
            _loggingService = loggingService;
        }
        public void Exit()
        {

        }

        public void Enter()
        {
            _ = InitializeServices().ProcessErrors();
            _loggingService.LogMessage("Bootstrap start");


        }

        private async Task InitializeServices()
        {
            foreach (var service in _initializableServices)
                await service.InitializeAsync();

            _stateMachine.Enter<LoadMetaState>();
        }


    }
}

