using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip mainMenuMusic;
    public AudioClip buttonClickingSound;
    private bool musicStatus = true;
    private bool sfxStatus = true;
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
            audioSource.Play();
            audioSource.loop = true;
        }
    }
    public void MusicOnOffButton()
    {
        if (musicStatus)
        {
            musicStatus = false;
            ChangeMusic(null);
        }
        else
        {
            musicStatus = true;
            ChangeMusic(mainMenuMusic);
        }
    }
    public void SfxOnOffButton()
    {
        if (sfxStatus)
        {
            sfxStatus = false;
        }
        else
        {
            sfxStatus = true;
        }
    }
    
    public bool getMusicStatus()
    {
        return musicStatus;
    }
    
    public bool getSfxStatus()
    {
        return sfxStatus;
    }
    
    public void PlayButtonClickingSound()
    {
        if (sfxStatus)
        { 
            audioSource.PlayOneShot(buttonClickingSound, 0.2f); 
        }
    }
}
