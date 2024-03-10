using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour
{
    public int presscount = 0; 
    private SoundManager _soundManager;
    public UnityEngine.UI.RawImage Img1;
    public UnityEngine.UI.RawImage Img2;
    
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("GameManager") != null)
        {
            // GameObject exists 
            _soundManager = GameObject.Find("GameManager").GetComponent<SoundManager>();
        }
    } 
    
    public void OnClick()
    {
        if (GameObject.Find("GameManager") != null)
        {
            _soundManager.PlayButtonClickingSound();
        }
        if (SceneManager.GetActiveScene().buildIndex == 1)
        { 
            // plot explaining button
            presscount++;
            if (Img1 != null && Img2 != null)
                {
                    // Img1'in görünürlüğünü kapat
                    Img1.enabled = false;

                    // Img2'nin görünürlüğünü aç
                    Img2.enabled = true;
                }

            if (presscount == 2)
            {
                // Img1 ve Img2 RawImage'lerini bul

                // Eğer Img1 ve Img2 null değilse, görünürlüklerini değiştir
                
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
