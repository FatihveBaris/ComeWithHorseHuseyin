using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class atSound : MonoBehaviour
{
   
    private AudioSource audioSource;
    public AudioClip scene3Sound;

    void Start()
    {
        // SceneManager'� sahne y�kleme olaylar�n� dinlemek i�in kullan�n
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Sahne y�klenen sahne 3 ise ve ses �alm�yorsa
        if (scene.buildIndex == 3 && !audioSource.isPlaying)
        {
            audioSource.clip = scene3Sound;
            // Ses �almaya ba�la
            audioSource.Play();
        }
    }

    // Opsiyonel olarak, oyun sahne d���nda oldu�unda sesi durdurabilirsiniz
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

}


