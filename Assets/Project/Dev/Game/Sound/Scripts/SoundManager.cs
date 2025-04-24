using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SoundManager: ITickable, IInitializable
{
    private void sdsd()
    {
        Debug.Log("саунд манагер");
    }

    private void SoundUpdate()
    {
        Debug.Log("sound update");
        Debug.Log("1");
    }


    public void Tick()
    {
        SoundUpdate();
    }

    public void Initialize()
    {
        sdsd();
    }
}
