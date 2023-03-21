using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    
    public enum itemType {heal, rapidFire, doubleTap, shield};   
    private GameObject player;
    public itemType typeOfItem;
    
    void Start() 
    {
        player=GameObject.Find("Player");    
        switch(Random.Range(1,5))
        {
            case 1:
                typeOfItem=itemType.heal;
                break;
            case 2:
                typeOfItem=itemType.rapidFire;
                break;
            case 3:
                typeOfItem=itemType.doubleTap;
                break;
            case 4:
                typeOfItem=itemType.shield;
                break;
        }
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
        handlePickUp();
    }

    
    private void handlePickUp()
    {
        if(typeOfItem==itemType.heal)
        {
            player.GetComponent<PlayerDamageController>().ChangeHealth(1);
        }
        else if(typeOfItem==itemType.rapidFire)
        {
            player.GetComponent<PlayerAttackController>().rapidFire=true;
        }
        else if(typeOfItem==itemType.doubleTap)
        {
            player.GetComponent<PlayerAttackController>().doubleTap=true;
        }
        else if(typeOfItem==itemType.shield)
        {
            player.GetComponent<PlayerDamageController>().shieldOn();
        }
    }

}
