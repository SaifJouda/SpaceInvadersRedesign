using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelController : MonoBehaviour
{
    public TMP_Text objectText;
    public GameObject enemyPrefab1;
    public GameObject bossPrefab;
    int level=12;
    int enemiesRemaining;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        objectText.text="Level: " + level.ToString();
        InitiateLevel();
        player=GameObject.Find("Player");
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
                SummonRowOfEnemies(15,-11.25f,5f);
                enemiesRemaining=15;
                break;
            case 2:
                SummonRowOfEnemies(11,-8.25f,5f);
                SummonRowOfEnemies(15,-11.25f,6.5f);
                enemiesRemaining=26;
                break;
            case 3:
                SummonBoss(new Vector2(0,5f), 10, 100, 1, 3);
                enemiesRemaining=1;
                break;
            case 4:
                SummonRowOfEnemies(7,-5.25f,3.5f);
                SummonRowOfEnemies(11,-8.25f,5f);
                SummonRowOfEnemies(15,-11.25f,6.5f);
                enemiesRemaining=33;
                break;
            case 5:
                SummonRowOfEnemies(5,-11.25f,5f);
                SummonRowOfEnemies(5,3.75f,5f);
                SummonBoss(new Vector2(0,5f), 10, 100, 1, 3);
                enemiesRemaining=11;
                break;
            case 6:
                SummonRowOfEnemies(15,-11.25f,3.5f);
                SummonRowOfEnemies(15,-11.25f,5.0f);
                SummonRowOfEnemies(15,-11.25f,6.5f);
                enemiesRemaining=45;
                break;
            case 7:
                SummonRowOfEnemies(5,-11.25f,5f);
                SummonRowOfEnemies(5,3.75f,5f);
                SummonRowOfEnemies(15,-11.25f,3f);
                SummonBoss(new Vector2(0,5f), 10, 100, 1, 3);
                enemiesRemaining=26;
                break;
            case 8:
                SummonRowOfEnemies(5,-11.25f,5f);
                SummonRowOfEnemies(5,3.75f,5f);
                SummonBoss(new Vector2(0,5f), 10, 100, 1, 3);

                SummonRowOfEnemies(5,-11.25f,2.5f);
                SummonRowOfEnemies(5,3.75f,2.5f);
                SummonBoss(new Vector2(0,2.5f), 10, 100, 1, 3);
                enemiesRemaining=22;
                break;
            case 9:
                SummonRowOfEnemies(15,-11.25f,2.0f);
                SummonRowOfEnemies(15,-11.25f,3.5f);
                SummonRowOfEnemies(15,-11.25f,5.0f);
                SummonRowOfEnemies(15,-11.25f,6.5f);
                enemiesRemaining=60;
                break;
            case 10:
                SummonBoss(new Vector2(-8.25f,2.5f), 5, 100, 1, 3);
                SummonBoss(new Vector2(-4.25f,5f), 5, 100, 1, 3);
                SummonBoss(new Vector2(8.25f,2.5f), 5, 100, 1, 3);
                SummonBoss(new Vector2(4.25f,5f), 5, 100, 1, 3);
                enemiesRemaining=4;
                break;
            case 11:
                SummonBoss(new Vector2(-4.25f,2.5f), 7, 100, 1, 3);
                SummonBoss(new Vector2(0f,5f), 7, 100, 1, 3);
                SummonBoss(new Vector2(4.25f,2.5f), 7, 100, 1, 3);
                SummonBoss(new Vector2(0f,0f), 7, 100, 1, 3);
                enemiesRemaining=4;
                break;
            case 12:
                SummonBoss(new Vector2(0,6f), 30, 100, 1, 2);
                enemiesRemaining=1;
                break;


        }

    }

    private void SummonRowOfEnemies(int numEnemies, float xPos, float yPos)
    {
        float x=xPos;
        float y=yPos;
        for(int i=0;i<=numEnemies;i++)
        {
            Instantiate(enemyPrefab1, new Vector2(x,y), transform.rotation);
            x+=1.5f;
        }
    }

    private void SummonBoss(Vector2 pos, int hp, int scr, int atkMin, int atkMax)
    {
        GameObject boss = Instantiate(bossPrefab, pos, transform.rotation);
        boss.GetComponent<EnemyDamageController>().maxHealth = hp;
        boss.GetComponent<EnemyDamageController>().score = scr;
        boss.GetComponent<EnemyShooting>().attackCoolDownMin = atkMin;
        boss.GetComponent<EnemyShooting>().attackCoolDownMax = atkMax;
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
        if(level==12)
        {
            //Finish
        }
        else
        {
            level++;
            objectText.text="Level: " + level.ToString();
            player.GetComponent<PlayerDamageController>().ChangeHealth(2);
        }
    }
}
