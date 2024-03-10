using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Main_menu : MonoBehaviour
{
    public Canvas SettingsCanvas;
    public Canvas MainMenuCanvas;
    public Canvas CreditsCanvas;
    public Canvas StoryCanvas;
    public void StartButton()
    {   //Daha belli de�il diye default de�er olarak 1 atad�m.

        SceneManager.LoadScene(1);
    }

    public void SettingsButton()
    {
        StoryCanvas.gameObject.SetActive(false);
        MainMenuCanvas.gameObject.SetActive(false);
        CreditsCanvas.gameObject.SetActive(false);
        SettingsCanvas.gameObject.SetActive(true);
    }

    public void CreditsButton()
    {
        StoryCanvas.gameObject.SetActive(false);
        MainMenuCanvas.gameObject.SetActive(false);
        SettingsCanvas.gameObject.SetActive(false);
        CreditsCanvas.gameObject.SetActive(true);
    }

    public void ReturnButton() 
    {
        SettingsCanvas.gameObject.SetActive(false);
        CreditsCanvas.gameObject.SetActive(false) ;
        MainMenuCanvas.gameObject.SetActive(true);
        StoryCanvas.gameObject.SetActive(false);
    }
    public void ReturnButton2()
    {
        SettingsCanvas.gameObject.SetActive(false);
        CreditsCanvas.gameObject.SetActive(false);
        StoryCanvas.gameObject.SetActive(false);
        MainMenuCanvas.gameObject.SetActive(true);
    }
    public void StoryButton()
    {
        
        SettingsCanvas.gameObject.SetActive(false);
        CreditsCanvas.gameObject.SetActive(false);
        MainMenuCanvas.gameObject.SetActive(false);
        StoryCanvas.gameObject.SetActive(true);

    }
    public void QuitButton()
    {
        Application.Quit();
    
    }
}
