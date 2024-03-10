using System;
using UnityEngine;
using UnityEngine.SceneManagement; 
using System.Collections.Generic; 
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int money = 20;
    public int oynananMac = 0;
    public static int BirinciSecilenAt;
    public static int IkinciSecilenAt;
    public static int UcuncuSecilenAt;
    public static int DorduncuSecilenAt;
    public static bool signal = false;
    private ToggleController _toggleController;
    private List<String> reqList;
    private void Awake()
    { 
            // Ensure the GameObject is not destroyed when loading a new scene
            DontDestroyOnLoad(gameObject); 
            // Subscribe to the sceneLoaded event
            SceneManager.sceneLoaded += OnSceneLoaded; 
    } 
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
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
                    BirinciSecilenAt = Convert.ToInt32(reqList[i].Substring(0, 1)); 
                }
                else if (reqList[i].EndsWith('2'))
                { 
                    IkinciSecilenAt = Convert.ToInt32(reqList[i].Substring(0, 1)); 
                }
                else if (reqList[i].EndsWith('3'))
                { 
                    UcuncuSecilenAt = Convert.ToInt32(reqList[i].Substring(0, 1)); 
                }
                else if (reqList[i].EndsWith('4'))
                { 
                    DorduncuSecilenAt = Convert.ToInt32(reqList[i].Substring(0, 1)); 
                }
            } 
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("EndingScreens"))
        {
            if (money > 10000)
            {
                GameObject.Find("GoodEnding").SetActive(true);
                GameObject.Find("WonTheBet").SetActive(false);
                GameObject.Find("GameOver").SetActive(false);
            }
            
        }
    }
} 
