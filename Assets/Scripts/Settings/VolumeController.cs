using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public Slider audioSlider;
    public TextMeshProUGUI volumeText;

    // Start is called before the first frame update
    void Start()
    {
        audioSlider.onValueChanged.AddListener(delegate { ChangeAudioLevel(audioSlider); });
    }

    private void ChangeAudioLevel(Slider slider)
    {
        volumeText.text = slider.value.ToString();
    }
}
