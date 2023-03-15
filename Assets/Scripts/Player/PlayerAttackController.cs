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
    public bool rapidFire=false;
    public bool doubleTap=false;
    public bool autoFire=false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if(autoFire==false)
        {
            if(Input.GetKeyDown(KeyCode.Space) && isAttackCooldown==false) Attack();
        }
        else
        {
            if(Input.GetKey(KeyCode.Space) && isAttackCooldown==false) Attack();
        }

        if(Input.GetKeyDown(KeyCode.L)) updateFireSpeed();
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
    }

    void Attack()
    {
        if(doubleTap=false)
        {
            GameObject projectileObject = Instantiate(projectileGameObject, transform.position, transform.rotation);
            projectileObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 20);
        }
        else
        {
            GameObject projectileObject1 = Instantiate(projectileGameObject, transform.position+new Vector3(-0.5f,0,0), transform.rotation);
            GameObject projectileObject2 = Instantiate(projectileGameObject, transform.position+new Vector3(0.5f,0,0), transform.rotation);
            projectileObject1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 20);
            projectileObject2.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 20);
        }
        
        isAttackCooldown=true;
        attackCooldownTimer=attackCooldown;
    }

    public void updateFireSpeed()
    {
        if(rapidFire==true)
        {
            attackCooldown=0.25f;
        }
    }
}
