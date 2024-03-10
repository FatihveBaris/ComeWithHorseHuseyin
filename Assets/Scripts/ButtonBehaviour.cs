using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour
{
    public int presscount = 0; 
    private SoundManager _soundManager;
    
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("SoundManager") != null)
        {
            // GameObject exists 
            _soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        }
    } 
    
    public void OnClick()
    {
        _soundManager.PlayButtonClickingSound();
        if (SceneManager.GetActiveScene().buildIndex == 1)
        { 
            // plot explaining button
            presscount++;
            if (presscount == 2)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        else if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            // ending buttonları
            if (this.gameObject.name=="BackToMainMenu")
            {
                SceneManager.LoadScene(0); 
            }
            else
            {
                SceneManager.LoadScene(2);  
            }
        }
        else
        {
            // diğer buttonlar
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
        }
    }
}
