using System;
using UnityEngine;
using UnityEngine.SceneManagement; 
using System.Collections.Generic; 
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int money = 20;
    public int oynananMac = 0;
    public int HuseyininSectigiAt;
    public static bool signal = false;
    private ToggleController _toggleController;
    private List<String> reqList;
    private void Start()
    {
        
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("GamblingMenu") && signal)
        {
            _toggleController = GameObject.FindWithTag("BiletTikParent").GetComponent<ToggleController>();
            signal = false;
            reqList = _toggleController.GetSelectedToggles();
            for (int i = 0; i < reqList.Count; i++)
            {
                if (reqList[i].EndsWith('1'))
                {
                    // Birinci atı tespit eden kod.
                    HuseyininSectigiAt = Convert.ToInt32(reqList[i].Substring(0, 1));
                    break;
                }
            }
        }
    }
} 
