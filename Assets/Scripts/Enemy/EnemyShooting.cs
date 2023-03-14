using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    //Attack Cooldow
    public GameObject projectileGameObject;
    public float attackCoolDownMin=10f;
    public float attackCoolDownMax=30f;
    float attackCooldownTimer=0;


    void Start()
    {
        attackCooldownTimer=Random.Range(attackCoolDownMin,attackCoolDownMax);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        attackCooldownTimer -= Time.deltaTime;
        if(attackCooldownTimer<=0)
        {
            Shoot();
            attackCooldownTimer=Random.Range(attackCoolDownMin,attackCoolDownMax);
        }
        
    }

    void Shoot()
    {
        GameObject projectileObject = Instantiate(projectileGameObject, transform.position, transform.rotation);
        //Vector2 launchDirection = attackPoint.transform.up;
        projectileObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -20);
    }
}
