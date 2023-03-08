using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public TMP_Text objectText;
    public int score;

    void Start()
    {
        score=0;
    }
    // Update is called once per frame
    void Update()
    {
        objectText.text="Score: " + score.ToString();
    }
}
