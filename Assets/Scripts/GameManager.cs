using System;
using UnityEngine;
using UnityEngine.SceneManagement; 
using System.Collections.Generic; 
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   // public int money = 20;
    public int oynananMac = 0;
    public static GameObject[] kazananlar;
    public static int BirinciSecilenAt;
    public static int IkinciSecilenAt;
    public static int UcuncuSecilenAt;
    public static int DorduncuSecilenAt;
    public static bool signal = false;  
    private Dictionary<int, string> horseNameMap = new Dictionary<int, string>
    {
        {0, "Black Horse"},
        {1, "Brown Horse"},
        {2, "Golden Horse"},
        {3, "White Horse"} 
        // Add more entries as needed
    };

    private ToggleController _toggleController;
    private List<String> reqList;
    private void Awake()
    { 
            // Ensure the GameObject is not destroyed when loading a new scene
            DontDestroyOnLoad(gameObject); 
            // Subscribe to the sceneLoaded event
            SceneManager.sceneLoaded += OnSceneLoaded; 
            SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void FixedUpdate()
    {
        if (signal)
        {
            Debug.Log("girdim");
            signal = false;
            _toggleController = GameObject.FindWithTag("BiletTikParent").GetComponent<ToggleController>(); 
            reqList = _toggleController.GetSelectedToggles();
            for (int i = 0; i < reqList.Count; i++)
            {
                Debug.Log(reqList[i]);
                if (reqList[i].EndsWith('0'))
                {
                    // Birinci atı tespit eden kod.
                    BirinciSecilenAt = Convert.ToInt32(reqList[i].Substring(0, 1)); 
                    Debug.Log($"Birinci at: {GetHorseName(BirinciSecilenAt)}");
                }
                else if (reqList[i].EndsWith('1'))
                { 
                    IkinciSecilenAt = Convert.ToInt32(reqList[i].Substring(0, 1)); 
                    Debug.Log($"İkinci at: {GetHorseName(BirinciSecilenAt)}");
                }
                else if (reqList[i].EndsWith('2'))
                { 
                    UcuncuSecilenAt = Convert.ToInt32(reqList[i].Substring(0, 1));  
                    Debug.Log($" Ucuncu at: {GetHorseName(BirinciSecilenAt)}");
                }
                else if (reqList[i].EndsWith('3'))
                { 
                    DorduncuSecilenAt = Convert.ToInt32(reqList[i].Substring(0, 1)); 
                    Debug.Log($" Ucuncu at: {GetHorseName(DorduncuSecilenAt)}");
                }
            } 
        }
    }

    private void OnSceneUnloaded(Scene scene)
    {
        if (scene.name == "GamblingMenu")
        {
            Debug.Log("GamblingMenu scene unloaded");
            
        } 
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    { 
        Debug.Log("İçeri girdik.");
        if (scene.buildIndex == 4) // çalışmıyor.
        { 
            Debug.Log($"EndingScreens scene loaded, BirinciSecilenAt: {GetHorseName(BirinciSecilenAt)}, Oyundan gelen: {kazananlar[0].name}");
            if (GetHorseName(BirinciSecilenAt) == kazananlar[0].name)
            {
                //GameObject.Find("GoodEnding").SetActive(false);
                GameObject.Find("WonTheBet").SetActive(true);
                GameObject.Find("GameOver").SetActive(false);
            }
            else
            {
                //GameObject.Find("GoodEnding").SetActive(false);
                GameObject.Find("WonTheBet").SetActive(false);
                GameObject.Find("GameOver").SetActive(true);
            } 
        }
    }
    
    private string GetHorseName(int horseNumber)
    {
        string horseName;
        if (horseNameMap.TryGetValue(horseNumber, out horseName))
        {
            return horseName;
        }
        else
        {
            Debug.LogError($"Horse name not found for horse number {horseNumber}");
            return "Unknown";
        }
    }
} 
