using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public Slider audioSlider;
    public TextMeshProUGUI volumeText;

    [Header("Volume Type")]
    public bool master = false;
    public bool music = false;
    public bool sfx = false;

    private GameObject backgroundAudio;

    // Start is called before the first frame update
    void Start()
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

        backgroundAudio = GameObject.FindWithTag("GameMenuMusic");

        if (master)
        {
            audioSlider.value = PlayerPrefs.GetFloat("MasterAudioLevel") * 100;
            volumeText.text = audioSlider.value.ToString();
        }
        else if (music)
        {
            audioSlider.value = PlayerPrefs.GetFloat("MusicAudioLevel") * 100;
            volumeText.text = audioSlider.value.ToString();
        }
        else if (sfx)
        {
            audioSlider.value = PlayerPrefs.GetFloat("SFXAudioLevel") * 100;
            volumeText.text = audioSlider.value.ToString();
        }

        audioSlider.onValueChanged.AddListener(delegate { ChangeAudioLevel(audioSlider); });
    }

    private void ChangeAudioLevel(Slider slider)
    {
        volumeText.text = slider.value.ToString();

        if (master)
        {
            PlayerPrefs.SetFloat("MasterAudioLevel", (slider.value)/100);
            PlayerPrefs.Save();
            backgroundAudio.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("MasterAudioLevel")*PlayerPrefs.GetFloat("MusicAudioLevel");
        }
        else if (music)
        {
            PlayerPrefs.SetFloat("MusicAudioLevel", (slider.value) / 100);
            PlayerPrefs.Save();
            backgroundAudio.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("MasterAudioLevel") * PlayerPrefs.GetFloat("MusicAudioLevel");
        }
        else if(sfx)
        {
            PlayerPrefs.SetFloat("SFXAudioLevel", (slider.value) / 100);
            PlayerPrefs.Save();
        }

    }
}
