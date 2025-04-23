using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BootStrap 
{
    private GameManager _gameManager;

    public BootStrap(GameManager gameManager)
    {
        _gameManager = gameManager;
        _gameManager.Sound();
    }
    
}
