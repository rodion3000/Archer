using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Zenject;

public class Infrascrtucture : MonoInstaller
{
    [SerializeField] private GameObject curtainServicePrefab;
    public override void InstallBindings()
    {
        BindServices();
    }

    private void BindServices()
    {
        Container.BindInterfacesAndSelfTo<CurtainService>()
            .FromComponentInNewPrefab(curtainServicePrefab)
            .WithGameObjectName("Curtain")
            .UnderTransformGroup("Infrastructure")
            .AsSingle().NonLazy();
    }
}
