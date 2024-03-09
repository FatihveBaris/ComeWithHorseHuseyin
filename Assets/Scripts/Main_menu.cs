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

        SceneManager.LoadScene(1);
    }

    public void SetttingsButton()
    {
        MainMenuCanvas.GetComponent<Canvas>().enabled = false;
        CreditsCanvas.GetComponent<Canvas>().enabled = false;
        SettingsCanvas.GetComponent<Canvas>().enabled = true;
    }

    public void CreditsButton()
    {
        MainMenuCanvas.GetComponent<Canvas>().enabled = false;
        SettingsCanvas.GetComponent<Canvas>().enabled = false;
        CreditsCanvas.GetComponent <Canvas>().enabled = true;
    }

    public void QuitButton()
    {
        Application.Quit();
    
    }
}
