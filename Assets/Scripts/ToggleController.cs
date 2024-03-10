using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleController : MonoBehaviour
{
    // Select butonlarınızın listesi
    public Toggle[] toggles;
    private GameManager _gameManager; 
    void Start()
    {
        foreach (var toggle in toggles)
        {
            // Her bir butona bir listener ekler
            toggle.onValueChanged.AddListener(delegate {
                UpdateToggles(toggle);
            });
        }
        
        if (GameObject.FindWithTag("GameManager") != null)
        {
            _gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
            switch (_gameManager.oynananMac)
            {
                case 0:
                    GameObject.Find("Kosu1").GetComponent<Toggle>().isOn = true;
                    break;
                case 1:
                    GameObject.Find("Kosu2").GetComponent<Toggle>().isOn = true;
                    break;
                case 2:
                    GameObject.Find("Kosu3").GetComponent<Toggle>().isOn = true;
                    break;
                case 3:
                    GameObject.Find("Kosu4").GetComponent<Toggle>().isOn = true;
                    break;
                case 4:
                    GameObject.Find("Kosu5").GetComponent<Toggle>().isOn = true;
                    break;
                case 5:
                    GameObject.Find("Kosu6").GetComponent<Toggle>().isOn = true;
                    break;
                default:
                    Debug.LogError("ToggleController.cs: Start() içindeki switch case'de hata var.");
                    break;
            }
            _gameManager.oynananMac++;
        }
    }

    void UpdateToggles(Toggle changedToggle)
    {
        string changedName = changedToggle.name;
        bool isOn = changedToggle.isOn;

        if (isOn)
        {
            foreach (var toggle in toggles)
            {
                // Değiştirilen buton hariç, baş veya son karakteri aynı olan diğer butonların 'Is On' durumunu false yapar
                if (toggle != changedToggle && (toggle.name[0] == changedName[0] || toggle.name[1] == changedName[1]))
                {
                    toggle.isOn = false;
                }
            }
        }
    }

    // Method to get all selected toggles
    public List<String> GetSelectedToggles()
    {
        List<String> selectedToggles = new List<String>();

        foreach (var toggle in toggles)
        {
            if (toggle.isOn)
            {
                selectedToggles.Add(toggle.name);
            }
        }

        return selectedToggles;
    }
} 

