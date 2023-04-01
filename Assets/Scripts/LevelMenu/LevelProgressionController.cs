using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class LevelProgressionController : MonoBehaviour
{
    public int level = 1;

    [Header("Green Arrow Direction")]
    public bool down = false;
    public bool left = false;
    public bool right = false;

    [Header("Green Arrow Objects")]
    public GameObject downArrow;
    public GameObject leftArrow;
    public GameObject rightArrow;

    [Header("Current Level Indicator")]
    public GameObject indicator;

    [Header("Level Frame")]
    public GameObject frame;

    private int progressedLevel;

    // Start is called before the first frame update
    void Awake()
    {
        // check for player progression (set to 1 if not found)
        if (!PlayerPrefs.HasKey("PlayerProgressedLevel"))
        {
            PlayerPrefs.SetInt("PlayerProgressedLevel", 1);
            PlayerPrefs.Save();
        }

        progressedLevel = PlayerPrefs.GetInt("PlayerProgressedLevel");

        if (level < progressedLevel)
        {
            downArrow.SetActive(down);
            leftArrow.SetActive(left);
            rightArrow.SetActive(right);
            indicator.SetActive(false);
            frame.GetComponent<Image>().color = Color.green;
        }

        if (level == progressedLevel)
        {
            indicator.SetActive(true);
        }

    }

}
