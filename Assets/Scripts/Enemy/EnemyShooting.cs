using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    //Attack Cooldow
    public GameObject projectileGameObject;
    float attackCooldownTimer=0;

    // Update is called once per frame
    void FixedUpdate()
    {
        attackCooldownTimer -= Time.deltaTime;
        if(attackCooldownTimer<=0)
        {
            Shoot();
            attackCooldownTimer=Random.Range(5.0f,15f);
        }
        
    }

    void Shoot()
    {
        GameObject projectileObject = Instantiate(projectileGameObject, transform.position, transform.rotation);
        //Vector2 launchDirection = attackPoint.transform.up;
        projectileObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -20);
    }
}
