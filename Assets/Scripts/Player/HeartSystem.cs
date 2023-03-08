using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartSystem : MonoBehaviour
{
    [HideInInspector]
    public int health;
    [HideInInspector]
    public int maxHealth;

    public GameObject[] hearts;
    public Sprite heartFull;
    public Sprite heartEmpty;

    void Update()
    {
        health=GetComponent<PlayerDamageController>().currentHealth;
        maxHealth=GetComponent<PlayerDamageController>().maxHealth;
        if(health>maxHealth)
            health=maxHealth;
        if(health<0)
            health = 0;
        for (int i=0;i<hearts.Length;i++)
        {
            if(i<health)
                hearts[i].GetComponent<SpriteRenderer>().sprite=heartFull;
            else
                hearts[i].GetComponent<SpriteRenderer>().sprite=heartEmpty;
            if(i<maxHealth)
                hearts[i].active=true;
            else
                hearts[i].active=false;
        }
    }
}
