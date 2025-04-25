using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GamePlaySceneInstaller : MonoInstaller
{
    [SerializeField] private PlayerAttackConfig _playerAttackConfig;
    [SerializeField] private PlayerAnimationConfig _playerAnimationConfig;
    public override void InstallBindings()
    {
        Initialize();
        Player();
    }

    private void Player()
    {
        Container.Bind<PlayerAttackConfig>().FromInstance(_playerAttackConfig);
        Container.Bind<PlayerAnimationConfig>().FromInstance(_playerAnimationConfig);
        Container.Bind<PlayerAnimationController>().AsSingle();
        Container.Bind<PlayerAttack>().AsSingle();
    }

    private void Initialize()
    {
        Container.BindInterfacesAndSelfTo<SoundManager>().AsSingle();
        Container.BindInterfacesAndSelfTo<GameEffect>().AsSingle();
        Container.Bind<GameManager>().AsSingle();
    } 
}
