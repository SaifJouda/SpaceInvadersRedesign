using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageController : MonoBehaviour
{
    
    public GameObject player;
    public GameObject mainController;
    public GameObject powerUpPrefab;
    //General Stats
    public int maxHealth = 1;
    public int currentHealth;
    public int score= 10;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        //////////////
        // V V Monitor if experience lag when loading levels with large amounts of enemies
        //player=GameObject.Find("Player");
        mainController=GameObject.Find("Main Controller");
    }

    public void ChangeHealth(int amount)
    {
        if(currentHealth<=0)
            return;

        currentHealth +=amount;

        if(currentHealth<=0)
        {
            Die();
        }

    }

    void Die()
    {
        mainController.GetComponent<LevelController>().UpdateKillCount();
        mainController.GetComponent<ScoreController>().score += score;
        mainController.GetComponent<ScoreController>().kills++;
        if(Random.Range(0, 5)==1)
        {
            GameObject powerUp = Instantiate(powerUpPrefab, transform.position, transform.rotation);
            powerUp.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -10);
            //itemType[] values = (itemType[])Enum.GetValues(typeof(powerUp.GetComponent<PowerUp>().itemType)) //(itemType[])Enum.GetValues(typeof(itemType));
            //itemType randomItemType = values[rand.Next(values.Length)];
            //powerUp.GetComponent<PowerUp>().typeOfItem=Enum.GetValues(typeof(powerUp.GetComponent<PowerUp>().itemType));//[Random.Range(0, 2)];
        }
        Destroy(gameObject);
    }
}
