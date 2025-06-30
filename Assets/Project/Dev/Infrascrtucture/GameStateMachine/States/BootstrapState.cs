using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Dev.Infrastructure.GameStateMachine.Interface;
using Project.Dev.Services.Interfaces;
using UnityEditor.VersionControl;
using System.Collections.Generic;
using System.Threading.Tasks;
using Zenject;

namespace Project.Dev.Infrastructure.GameStateMachine.States
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly List<IInitializableAsync> _initializableServices;

        public BootstrapState(GameStateMachine stateMachine, List<IInitializableAsync> initializableServices)
        {
            _stateMachine = stateMachine;
            _initializableServices = initializableServices;
        }
        public void Exit()
        {

        }

        public void Enter()
        {


        }

        
    }
}

