using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class ResetPlayerProgression : MonoBehaviour
{
    public void ResetProgression()
    {
        PlayerPrefs.SetInt("PlayerProgressedLevel", 1);
        PlayerPrefs.Save();

        SceneManager.LoadScene("LevelSelection");
    }


}
