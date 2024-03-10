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
        // SceneManager'ý sahne yükleme olaylarýný dinlemek için kullanýn
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Sahne yüklenen sahne 3 ise ve ses çalmýyorsa
        if (scene.buildIndex == 3 && !audioSource.isPlaying)
        {
            audioSource.clip = scene3Sound;
            // Ses çalmaya baþla
            audioSource.Play();
        }
    }

    // Opsiyonel olarak, oyun sahne dýþýnda olduðunda sesi durdurabilirsiniz
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

}


