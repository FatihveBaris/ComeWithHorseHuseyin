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
        {1, "Black Horse"},
        {2, "Brown Horse"},
        {3, "Golden Horse"},
        {4, "White Horse"} 
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
                if (reqList[i].EndsWith('0'))
                {
                    // Birinci atı tespit eden kod.
                    BirinciSecilenAt = Convert.ToInt32(reqList[i].Substring(0, 1)); 
                }
                else if (reqList[i].EndsWith('1'))
                { 
                    IkinciSecilenAt = Convert.ToInt32(reqList[i].Substring(0, 1)); 
                }
                else if (reqList[i].EndsWith('2'))
                { 
                    UcuncuSecilenAt = Convert.ToInt32(reqList[i].Substring(0, 1)); 
                }
                else if (reqList[i].EndsWith('3'))
                { 
                    DorduncuSecilenAt = Convert.ToInt32(reqList[i].Substring(0, 1)); 
                }
            } 
        } 
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("EndingScreens"))
        { 
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
