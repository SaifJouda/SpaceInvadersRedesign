using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBackgroundAudioController : MonoBehaviour
{
    void Awake()
    {
        GameObject[] backgroundAudio = GameObject.FindGameObjectsWithTag("GameMenuMusic");
        if (backgroundAudio.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

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
        //float sfxAudioLevel = PlayerPrefs.GetFloat("SFXAudioLevel");

        this.gameObject.GetComponent<AudioSource>().volume = masterAudioLevel * musicAudioLevel;

    }
}
