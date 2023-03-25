using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class SelectLevelController : MonoBehaviour
{
    public int level = 1;

    public GameObject comfirmUI;
    public TextMeshProUGUI levelText;
    public GameObject levelGrid;

    private int progressedLevel;

    public void GetComfirmation()
    {
        // check for player progression (TEMPORARY DEFAULT LEVEL 7 FOR NOW)
        if (!PlayerPrefs.HasKey("PlayerProgressedLevel"))
        {
            PlayerPrefs.SetInt("PlayerProgressedLevel", 7);
            PlayerPrefs.Save();
        }
        progressedLevel = PlayerPrefs.GetInt("PlayerProgressedLevel");

        if (!(level > progressedLevel))
        {
            comfirmUI.SetActive(true);
            levelText.text = "1-" + level.ToString() + "?";
            PlayerPrefs.SetInt("SelectedLevel", level);
            PlayerPrefs.Save();
        }
        else
        {
            BlinkCurrentLevelIndicator();
        }
    }

    private void BlinkCurrentLevelIndicator()
    {
        string levelName = "Level1_" + PlayerPrefs.GetInt("PlayerProgressedLevel").ToString();
        Transform trans = levelGrid.transform;
        Transform levelBtn = trans.Find(levelName);

        if (levelBtn != null)
        {
            Transform selctedIndicator = levelBtn.Find("IconSelected");
            if(selctedIndicator != null)
            {
                StartCoroutine(BlinkIcon(selctedIndicator));
            }
        }
    }

    IEnumerator BlinkIcon(Transform obj)
    {
        int i = 0;
        while (i < 4)
        {
            obj.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.25f);
            obj.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.25f);
            i++;
        }
    }
}
