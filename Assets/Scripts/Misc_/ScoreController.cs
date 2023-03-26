using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public TMP_Text objectText;
    public TMP_Text killsText;
    public TMP_Text highText;
    public int kills;
    private int score;
    private int high;
    public HighScoreData highScoreData;

    void Start()
    {
        score=0;
        kills=0;
        //highScoreData = ScriptableObject.CreateInstance<HighScoreData>();
        //highScoreData.highScore = 0;
        high=highScoreData.highScore;
        objectText.text="Score\n" + score.ToString();
        highText.text="High Score\n" + high.ToString();
        killsText.text="Enemies Slain: " + kills.ToString();
    }


    public void UpdateScore(int scoreAdd)
    {
        score+=scoreAdd;
        if(score>high)
        {
            highScoreData.highScore = score;
            high=score;
        }
        objectText.text="Score\n" + score.ToString();
        highText.text="High Score\n" + high.ToString();
        killsText.text="Enemies Slain: " + kills.ToString();
    }
}
