using System.Collections;
using System.Collections.Generic;
using Project.Dev.Infrastructure.GameStateMachine.States;
using UnityEngine;
using Zenject;

namespace Project.Dev.Infrascrtucture.Installers.ProjectInstallers
{
    public class GameStateMachineInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<BootstrapState>().AsSingle().NonLazy();
            Container.Bind<GameLoopState>().AsSingle().NonLazy();
            Container.Bind<GamePauseState>().AsSingle().NonLazy();
            Container.Bind<LoadLevelState>().AsSingle().NonLazy();
            Container.Bind<LoadMetaState>().AsSingle().NonLazy();
            Container.Bind<LoadProgresState>().AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<GameStateMachine>().AsSingle();
        }
    }
}

