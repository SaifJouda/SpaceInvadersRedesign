using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{

    public int damage=-1;

    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
        if(other.gameObject.GetComponent<EnemyDamageController>()!=null)
        {
            other.gameObject.GetComponent<EnemyDamageController>().ChangeHealth(damage);
        }   
    }
}