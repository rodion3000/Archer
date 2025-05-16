using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GamePlayInstaller : MonoInstaller
{
    [SerializeField] private GameObject playerPrefab;
    public override void InstallBindings()
    {
        BindPlayer();
    }

    private void BindPlayer()
    {
        Container.BindInterfacesAndSelfTo<SpineArcher>()
            .FromComponentInNewPrefab(playerPrefab)
            .WithGameObjectName("Player")
            .UnderTransformGroup("Gameplay")
            .AsSingle().NonLazy();
    }
    
}
