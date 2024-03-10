using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public int money = 20;
    public int oynananMac = 0; 

    private void Awake()
    { 
    }

    void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneAt(3))
        {
            HipodromManager();
        }
        
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneAt(2))
        {
            BahisManager();
        }
    }

    private void HipodromManager()
    {
        
    }
    
    private void BahisManager()
    { 
        
    }
}
