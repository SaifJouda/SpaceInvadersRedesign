using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerAttackController : MonoBehaviour
{
    public GameObject projectileGameObject;

    //Attack Cooldown
    private float attackCooldown = 0.5f;
    bool isAttackCooldown;
    float attackCooldownTimer;
    public bool rapidFire=false;
    //public bool doubleTap=false;
    public bool autoFire=false;

    public float doubleTapTime=0;
    //public SpriteRenderer doubleTapSprite;

    private KeyCode shootKeyCode;

    void Awake()
    {
        if (!PlayerPrefs.HasKey("AutoShoot"))
        {
            PlayerPrefs.SetInt("AutoShoot", 0);
            PlayerPrefs.Save();
        }
        if (!PlayerPrefs.HasKey("ShootKey"))
        {
            PlayerPrefs.SetString("ShootKey", KeyCode.Space.ToString());
            PlayerPrefs.Save();
        }
    }

    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.I)) rapidFire=!rapidFire;
        //if(Input.GetKeyDown(KeyCode.O)) doubleTap=!doubleTap;
        //if(Input.GetKeyDown(KeyCode.P)) autoFire=!autoFire;

        autoFire = PlayerPrefs.GetInt("AutoShoot") == 1;
        shootKeyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("ShootKey"));
        if (autoFire==false)
        {
            if(Input.GetKeyDown(shootKeyCode) && isAttackCooldown==false) Attack();
        }
        else
        {
            if(Input.GetKey(shootKeyCode) && isAttackCooldown==false) Attack();
        }

        if(Input.GetKeyDown(KeyCode.X)) doubleTapTime=5f;
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
        if(doubleTapTime>0) 
        {
            doubleTapTime-=Time.deltaTime;
        }
        
    }

    void Attack()
    {
        if(doubleTapTime<=0f)
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
        if(rapidFire==true) attackCooldownTimer=0.25f;
        else attackCooldownTimer=0.5f;
    }

    public void updateFireSpeed()
    {
        if(rapidFire==true)
        {
            attackCooldown=0.25f;
        }
    }
}
