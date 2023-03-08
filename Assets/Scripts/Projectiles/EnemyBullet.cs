using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int damage=-1;

    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
        if(other.gameObject.GetComponent<PlayerDamageController>()!=null)
        {
            other.gameObject.GetComponent<PlayerDamageController>().ChangeHealth(damage);
        }

    }
}
