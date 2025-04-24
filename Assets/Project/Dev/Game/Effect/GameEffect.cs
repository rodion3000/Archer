using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameEffect: ITickable
{
    public void Tick()
    {
        Debug.Log("GameEffect Tick");
    }
    
}
