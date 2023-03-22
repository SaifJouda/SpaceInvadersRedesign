using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public TMP_Text objectText;
    public TMP_Text killsText;
    public int score;
    public int kills;

    void Start()
    {
        score=0;
        kills=0;
    }
    // Update is called once per frame
    void Update()
    {
        objectText.text="Score\n" + score.ToString();
        killsText.text="Enemies Slain: " + kills.ToString();
    }
}
