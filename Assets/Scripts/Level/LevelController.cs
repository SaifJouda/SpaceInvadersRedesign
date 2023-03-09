using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelController : MonoBehaviour
{
    public TMP_Text objectText;
    public GameObject enemyPrefab1;
    int level=1;
    int enemiesRemaining;
    // Start is called before the first frame update
    void Start()
    {
        objectText.text="Level: " + level.ToString();
        InitiateLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitiateLevel()
    {
        float x;
        float y;
        switch(level)
        {
            case 1:
                x=-16;
                y=5;
                for(int i=0;i<=16;i++)
                {
                    Instantiate(enemyPrefab1, new Vector2(x,y), transform.rotation);
                    x+=2;
                }
                enemiesRemaining=16;
                break;
            case 2:
                x=-16;
                y=5;
                for(int i=0;i<=32;i++)
                {
                    Instantiate(enemyPrefab1, new Vector2(x,y), transform.rotation);
                    x+=2;
                    if(x==18)
                    {
                        x=-16;
                        y+=1.5f;
                    }
                }
                enemiesRemaining=32;
                break;
            case 3:
            
                break;
            case 4:
            
                break;
            case 5:
            
                break;
            case 6:
            
                break;
            case 7:
            
                break;
            case 8:
            
                break;
            case 9:
            
                break;
            case 10:
            
                break;
            case 11:
            
                break;
            case 12:
            
                break;


        }

    }

    public void UpdateKillCount()
    {
        enemiesRemaining-=1;
        if(enemiesRemaining<1)
        {
            UpdateLevel();
            InitiateLevel();
        }
    }

    public void UpdateLevel()
    {
        level++;
        objectText.text="Level: " + level.ToString();
    }
}
