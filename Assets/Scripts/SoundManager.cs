using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip mainMenuMusic;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ChangeMusic(mainMenuMusic);
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void ChangeMusic(AudioClip input)
    {
        if (audioSource != null)
        {
            audioSource.clip = input;
            audioSource.PlayOneShot(input);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
