using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeAudioLevel : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public AudioSource lazerSound;

    void Awake()
    {
        if (!PlayerPrefs.HasKey("MasterAudioLevel"))
        {
            PlayerPrefs.SetFloat("MasterAudioLevel", 1);
            PlayerPrefs.Save();
        }
        if (!PlayerPrefs.HasKey("MusicAudioLevel"))
        {
            PlayerPrefs.SetFloat("MusicAudioLevel", 1);
            PlayerPrefs.Save();
        }
        if (!PlayerPrefs.HasKey("SFXAudioLevel"))
        {
            PlayerPrefs.SetFloat("SFXAudioLevel", 1);
            PlayerPrefs.Save();
        }
        float masterAudioLevel = PlayerPrefs.GetFloat("MasterAudioLevel");
        float musicAudioLevel = PlayerPrefs.GetFloat("MusicAudioLevel");
        float sfxAudioLevel = PlayerPrefs.GetFloat("SFXAudioLevel");

        backgroundMusic.volume = masterAudioLevel * musicAudioLevel;
        lazerSound.volume = masterAudioLevel * sfxAudioLevel;
    }

}
