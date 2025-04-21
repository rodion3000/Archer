using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GamePlaySceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<GameManager>().AsSingle();
        Container.Bind<PlayerController>().AsSingle();
        Container.Bind<PlayerAnimationController>().AsSingle();
        Container.Bind<PlayerAttack>().AsSingle();
    }

    private void Player()
    {
        
    }
}
