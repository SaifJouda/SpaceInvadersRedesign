using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageController : MonoBehaviour
{
    public GameObject player;
    //General Stats
    public int maxHealth = 1;
    public int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        //////////////
        // V V Monitor if experience lag when loading levels with large amounts of enemies
        player=GameObject.Find("Player");
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
        player.GetComponent<ScoreController>().score += 10;
        Destroy(gameObject);
    }
}
