using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public int health;
    
    public void damageShield(int damage)
    {
        health-=damage;
        if(health<=0)
        {
            Destroy(gameObject);
        }
    }
}
