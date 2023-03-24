using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameplayOptionsController : MonoBehaviour
{
    public Toggle autoShootToggle;

    void Awake()
    {
        if (!PlayerPrefs.HasKey("AutoShoot"))
        {
            PlayerPrefs.SetInt("AutoShoot", 0);
            PlayerPrefs.Save();
        }

        bool autoShootEnabled = PlayerPrefs.GetInt("AutoShoot")==1;

        if (autoShootEnabled)
        {
            autoShootToggle.isOn = true;
        }
        else
        {
            autoShootToggle.isOn = false;
        }

        autoShootToggle.onValueChanged.AddListener(delegate { ChangeShootingMode(autoShootToggle); });
    }

    private void ChangeShootingMode(Toggle toggle)
    {
        if (toggle.isOn)
        {
            PlayerPrefs.SetInt("AutoShoot", 1);
            PlayerPrefs.Save();
        }
        else
        {
            PlayerPrefs.SetInt("AutoShoot", 0);
            PlayerPrefs.Save();
        }

    }
}
