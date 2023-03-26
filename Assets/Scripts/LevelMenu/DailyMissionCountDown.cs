using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using DateTime = System.DateTime;
using TimeSpan = System.TimeSpan;

public class DailyMissionCountDown : MonoBehaviour
{
    public TMP_Text timerTitle;
    public TMP_Text timerText;
    public UnityEvent OnComplete;

    private int secondDuration = 60;
    DateTime? currentTime;

    void Start()
    {

        if (!PlayerPrefs.HasKey("TimeUntilNextBonus"))
            return;

        var savedString = PlayerPrefs.GetString("TimeUntilNextBonus");
        if (long.TryParse(savedString, out long ticks))
        {
            currentTime = new DateTime(ticks);
        }
        else
        {
            currentTime = DateTime.Now;
        }

        timerTitle.gameObject.SetActive(true);
        timerText.gameObject.SetActive(true);

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

            timerText.text = (new TimeSpan(0, 0, currentSecond)).ToString(@"hh\:mm\:ss");

            yield return null;
        }

        currentTime = null;
        PlayerPrefs.DeleteKey("TimeUntilNextBonus");

        timerTitle.gameObject.SetActive(false);
        timerText.gameObject.SetActive(false);

        if (OnComplete != null)
            OnComplete.Invoke();
    }
}
