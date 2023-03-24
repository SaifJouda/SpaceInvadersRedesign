using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelController : MonoBehaviour
{
    public TMP_Text objectText;
    public GameObject enemyPrefab1;
    public GameObject enemyPrefab2;
    public GameObject enemyPrefab3;
    public GameObject enemyPrefab4;
    public GameObject bossPrefab;
    public GameObject shieldPrefab;
    int level=12;
    int enemiesRemaining;
    GameObject player;
    
    
    GameObject[] shields= new GameObject[5];
    
    // Start is called before the first frame update
    void Start()
    {
        objectText.text="Level\n" + level.ToString();
        InitiateLevel();
        player=GameObject.Find("Player");
    }

    

    public void InitiateLevel()
    {
        float x;
        float y;
        
        activateShields();

        switch(level)
        {
            case 1:
                GetComponent<DifficultyController>().enemyMoveSpeed=1;
                SummonRowOfEnemies(11,-6.25f,7.5f);
                SummonRowOfEnemies(11,-6.25f,6.5f);
                SummonRowOfEnemies(11,-6.25f,5.5f);
                SummonRowOfEnemies(11,-6.25f,4.5f);
                break;
            case 2:
                GetComponent<DifficultyController>().enemyMoveSpeed=2;
                SummonRowOfEnemies(11,-6.25f,7.5f);
                SummonRowOfEnemies(11,-6.25f,6.5f);
                SummonRowOfEnemies(11,-6.25f,5.5f);
                SummonRowOfEnemies(11,-6.25f,4.5f);           
                break;
            case 3:
                SummonBoss(new Vector2(0,7f), 10, 100, 1, 3);              
                break;
            case 4:
                GetComponent<DifficultyController>().enemyMoveSpeed=5;
                SummonRowOfEnemies(11,-6.25f,7.5f);
                SummonRowOfEnemies(11,-6.25f,6.5f);
             
                break;
            case 5:
                GetComponent<DifficultyController>().enemyMoveSpeed=2;
                SummonRowOfEnemies(4,-6.25f,7.5f);
                SummonRowOfEnemies(4,2.5f,7.5f);
                SummonRowOfEnemies(4,-6.25f,6.5f);
                SummonRowOfEnemies(4,2.5f,6.5f);
                SummonBoss(new Vector2(0.0f,7f), 10, 100, 1, 3);
               
                break;
            case 6:
                GetComponent<DifficultyController>().enemyMoveSpeed=3;
                SummonRowOfEnemies(11,-6.25f,7.5f);
                SummonRowOfEnemies(11,-6.25f,6.5f);
                SummonRowOfEnemies(11,-6.25f,5.5f);
                SummonRowOfEnemies(11,-6.25f,4.5f);  
               
                break;
            case 7:
                GetComponent<DifficultyController>().enemyMoveSpeed=4;
                SummonRowOfEnemies(11,-6.25f,7.5f);
                SummonRowOfEnemies(11,-6.25f,6.5f);
                SummonRowOfEnemies(11,-6.25f,5.5f);
                SummonRowOfEnemies(11,-6.25f,4.5f);  
          
                break;
            case 8:
            GetComponent<DifficultyController>().enemyMoveSpeed=3;
                SummonRowOfEnemies(2,-6.25f,7.5f);
                SummonRowOfEnemies(2,-6.25f,6.5f);
                SummonBoss(new Vector2(-2.5f,7f), 10, 100, 1, 3);
                SummonRowOfEnemies(1,0f,7.5f);
                SummonRowOfEnemies(1,0f,6.5f);
                SummonBoss(new Vector2(2.5f,7f), 10, 100, 1, 3);
                SummonRowOfEnemies(2,5f,7.5f);
                SummonRowOfEnemies(2,5f,6.5f);

           
                break;
            case 9:
                GetComponent<DifficultyController>().enemyMoveSpeed=4;
                SummonRowOfEnemies(11,-6.25f,7.5f);
                SummonRowOfEnemies(11,-6.25f,6.5f);
                SummonRowOfEnemies(11,-6.25f,5.5f);
                SummonRowOfEnemies(11,-6.25f,4.5f);  
             
                break;
            case 10:
                GetComponent<DifficultyController>().enemyMoveSpeed=2;
                SummonBoss(new Vector2(-6.25f,7.5f), 5, 100, 1, 3);
                SummonBoss(new Vector2(-4.25f,5f), 5, 100, 1, 3);
                SummonBoss(new Vector2(6.25f,7.5f), 5, 100, 1, 3);
                SummonBoss(new Vector2(4.25f,5f), 5, 100, 1, 3);
               
                break;
            case 11:
                GetComponent<DifficultyController>().enemyMoveSpeed=2;
                SummonBoss(new Vector2(-5.25f,6f), 5, 100, 1, 3);
                SummonBoss(new Vector2(0,7.5f), 5, 100, 1, 3);
                SummonBoss(new Vector2(5.25f,6f), 5, 100, 1, 3);
                SummonBoss(new Vector2(0,4.5f), 5, 100, 1, 3);
            
                break;
            case 12:
                GetComponent<DifficultyController>().enemyMoveSpeed=4;
                SummonRowOfEnemies(4,-6.25f,7.5f);
                SummonRowOfEnemies(4,2.5f,7.5f);
                SummonRowOfEnemies(4,-6.25f,6.5f);
                SummonRowOfEnemies(4,2.5f,6.5f);
                SummonBoss(new Vector2(0.0f,7f), 10, 100, 1, 3);
                SummonRowOfEnemies(11,-6.25f,5.5f);
                SummonRowOfEnemies(11,-6.25f,4.5f);  
                break;
            case 14:
                GetComponent<DifficultyController>().enemyMoveSpeed=5;
                SummonRowOfEnemies(4,-6.25f,7.5f);
                SummonRowOfEnemies(4,2.5f,7.5f);
                SummonRowOfEnemies(4,-6.25f,6.5f);
                SummonRowOfEnemies(4,2.5f,6.5f);
                SummonBoss(new Vector2(0.0f,7f), 10, 100, 1, 3);
                break;


        }

    }

    private void SummonRowOfEnemies(int numEnemies, float xPos, float yPos)
    {
        float x=xPos;
        float y=yPos;
        int num = Random.Range(1,5);
        GameObject enemy;
        for(int i=0;i<numEnemies;i++)
        {
            switch(num)
            {
                case 1:
                    Instantiate(enemyPrefab1, new Vector2(x,y), transform.rotation);
                    break;
                case 2:
                    Instantiate(enemyPrefab2, new Vector2(x,y), transform.rotation);
                    break;
                case 3:
                    Instantiate(enemyPrefab3, new Vector2(x,y), transform.rotation);
                    break;
                case 4:
                    Instantiate(enemyPrefab4, new Vector2(x,y), transform.rotation);
                    break;
            }
            
            //enemy = Instantiate(enemyPrefab1, new Vector2(x,y), transform.rotation);//.GetComponent<EnemyTypeController>();
            
            //enemy.GetComponent<EnemyTypeController>().typeOfEnemy = enemy.GetComponent<EnemyTypeController>().
            //enemy.GetComponent<EnemyTypeController>().setRandomType(num);
            //enemy.GetComponent<EnemyTypeController>().changeEnemy();
            enemiesRemaining++;
            x+=1.25f;
        }
    }

    private void SummonBoss(Vector2 pos, int hp, int scr, int atkMin, int atkMax)
    {
        GameObject boss = Instantiate(bossPrefab, pos, transform.rotation);
        boss.GetComponent<EnemyDamageController>().maxHealth = hp;
        boss.GetComponent<EnemyDamageController>().score = scr;
        boss.GetComponent<EnemyShooting>().attackCoolDownMin = atkMin;
        boss.GetComponent<EnemyShooting>().attackCoolDownMax = atkMax;
        enemiesRemaining++;
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
            player.GetComponent<PlayerDamageController>().ChangeHealth(1);
        }
    }

    void activateShields()
    {
        for(int i=0;i<5;i++)
        {
            if(shields[i]==null)
            {
                shields[i]=Instantiate(shieldPrefab, new Vector2(-15f+i*7.5f,-5.5f), transform.rotation);
                shields[i].GetComponent<Shield>().health=1;
            }

        }
    }
}
