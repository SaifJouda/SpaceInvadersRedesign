using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using DateTime = System.DateTime;
using TimeSpan = System.TimeSpan;

public class DailyMissionCountDown : MonoBehaviour
{
    public GameObject CountDownHeader;
    public TMP_Text timerText;
    public TMP_Text bonusText;

    private int secondDuration = 60;
    DateTime? currentTime;

    void Start()
    {

        if (!PlayerPrefs.HasKey("TimeUntilNextBonus"))
        {
            bonusText.color = Color.green;
            bonusText.text = ("Bonus: 1000");

            CountDownHeader.SetActive(false);

            return;
        }

        var savedString = PlayerPrefs.GetString("TimeUntilNextBonus");
        if (long.TryParse(savedString, out long ticks))
        {
            currentTime = new DateTime(ticks);
        }
        else
        {
            currentTime = DateTime.Now;
        }

        StartCoroutine(WaitForCompletion());
    }

    public void StartCountdown()
    {
        currentTime = DateTime.Now;

        PlayerPrefs.SetString("TimeUntilNextBonus", currentTime.Value.Ticks.ToString());
        PlayerPrefs.Save();

        StartCoroutine(WaitForCompletion());
    }

    IEnumerator WaitForCompletion()
    {
        int currentSecond = 1;

        while (currentSecond > 0)
        {
            var elapsed = DateTime.Now - currentTime.Value;
            currentSecond = Mathf.Max(secondDuration - (int)elapsed.TotalSeconds, 0);

            CountDownHeader.SetActive(true);
            timerText.text = (new TimeSpan(0, 0, currentSecond)).ToString(@"hh\:mm\:ss");
            timerText.color = Color.white;
            bonusText.color = Color.gray;
            bonusText.text = ("Bonus: 0");

            yield return null;
        }

        bonusText.color = Color.green;
        bonusText.text = ("Bonus: 1000");

        CountDownHeader.SetActive(false);

        currentTime = null;
        PlayerPrefs.DeleteKey("TimeUntilNextBonus");

    }
}
