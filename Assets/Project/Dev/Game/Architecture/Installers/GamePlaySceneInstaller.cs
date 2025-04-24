using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GamePlaySceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Initialize();
        Player();
    }

    private void Player()
    {
        Container.Bind<PlayerAnimationController>().AsSingle();
        Container.Bind<PlayerAttack>().AsSingle();
    }

    private void Initialize()
    {
        Container.BindInterfacesAndSelfTo<SoundManager>().AsSingle();
        Container.BindInterfacesAndSelfTo<GameEffect>().AsSingle();
        Container.Bind<GameManager>().AsSingle().NonLazy();
    } 
}
