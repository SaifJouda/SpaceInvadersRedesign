using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    public GameObject projectileGameObject;

    //Attack Cooldown
    private float attackCooldown = 0.5f;
    bool isAttackCooldown;
    float attackCooldownTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isAttackCooldown)
        {
            attackCooldownTimer -= Time.deltaTime;
            if (attackCooldownTimer <= 0)
                isAttackCooldown = false;
        }


        if(Input.GetKeyDown(KeyCode.Space) && isAttackCooldown==false)
        {
            Attack();
        }
    }

    void Attack()
    {
        GameObject projectileObject = Instantiate(projectileGameObject, transform.position, transform.rotation);
        //Vector2 launchDirection = attackPoint.transform.up;
        projectileObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 20);
        isAttackCooldown=true;
        attackCooldownTimer=attackCooldown;
    }
}
