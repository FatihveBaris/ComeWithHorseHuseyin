using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Main_menu : MonoBehaviour
{
    public Canvas SettingsCanvas;
    public Canvas MainMenuCanvas;
    public Canvas CreditsCanvas;
    public void StartButton()
    {   //Daha belli deðil diye default deðer olarak 1 atadým.

        SceneManager.LoadScene("HipodromScene");
    }

    public void SettingsButton()
    {
        MainMenuCanvas.gameObject.SetActive(false);
        CreditsCanvas.gameObject.SetActive(false);
        SettingsCanvas.gameObject.SetActive(true);
    }

    public void CreditsButton()
    {
        MainMenuCanvas.gameObject.SetActive(false);
        SettingsCanvas.gameObject.SetActive(false);
        CreditsCanvas.gameObject.SetActive(true);
    }

    public void ReturnButton() 
    {
        SettingsCanvas.gameObject.SetActive(false);
        CreditsCanvas.gameObject.SetActive(false) ;
        MainMenuCanvas.gameObject.SetActive(true);

    }
    public void QuitButton()
    {
        Application.Quit();
    
    }
}
