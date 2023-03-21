using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    
    public enum itemType {heal, rapidFire, doubleTap};   
    private GameObject player;
    public itemType typeOfItem;
    
    void Start() 
    {
        player=GameObject.Find("Player");    
        switch(Random.Range(1,4))
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
    }

}
