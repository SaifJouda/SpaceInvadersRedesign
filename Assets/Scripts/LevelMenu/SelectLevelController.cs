using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using DateTime = System.DateTime;

public class SelectLevelController : MonoBehaviour
{
    public int level = 1;

    public GameObject comfirmUI;
    public TextMeshProUGUI levelText;
    public GameObject levelGrid;

    private int progressedLevel;
    DateTime? waitTime = DateTime.Now.AddMinutes(1);

    public void GetComfirmation()
    {
        // check for player progression (set to 1 if not found)
        if (!PlayerPrefs.HasKey("PlayerProgressedLevel"))
        {
            PlayerPrefs.SetInt("PlayerProgressedLevel", 1);
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
        // level 14 is bonus daily mission level
        else if (level == 14)
        {
            comfirmUI.SetActive(true);
            levelText.text = "Damage Derby?";
            PlayerPrefs.SetInt("SelectedLevel", level);
            PlayerPrefs.Save();
        }
        else
        {
            BlinkCurrentLevelIndicator();
        }
    }

    public void InvokeDailyCountDown()
    {
        if (!PlayerPrefs.HasKey("TimeUntilNextBonus") && level == 14)
        {
            Debug.Log("Invoked Timer");
            PlayerPrefs.SetString("TimeUntilNextBonus", waitTime.Value.Ticks.ToString());
            PlayerPrefs.Save(); 
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
        while (i < 3)
        {
            obj.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.2f);
            obj.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            i++;
        }
    }
}
