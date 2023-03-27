using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    
    public enum itemType {heal, rapidFire, doubleTap, shield, shieldBlocks};   
    private GameObject player;
    private GameObject mainController;
    public itemType typeOfItem;
    public GameObject doubleSprite;
    public GameObject healthSprite;
    public GameObject rapidSprite;
    public GameObject shieldSprite;
    public GameObject barrierSprite;
    
    void Start() 
    {
        player=GameObject.Find("Player");    
        mainController=GameObject.Find("Main Controller");

        switch(Random.Range(1,6))
        {
            case 1:
                typeOfItem=itemType.heal;
                healthSprite.SetActive(true);
                break;
            case 2:
                typeOfItem=itemType.rapidFire;
                rapidSprite.SetActive(true);
                break;
            case 3:
                typeOfItem=itemType.doubleTap;
                doubleSprite.SetActive(true);
                break;
            case 4:
                typeOfItem=itemType.shield;
                shieldSprite.SetActive(true);
                break;
            case 5:
                typeOfItem=itemType.shieldBlocks;
                barrierSprite.SetActive(true);
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
            //player.GetComponent<PlayerAttackController>().doubleTap=true;
            player.GetComponent<PlayerAttackController>().doubleTapTime=5f;
        }
        else if(typeOfItem==itemType.shield)
        {
            player.GetComponent<PlayerDamageController>().shieldOn();
        }
        else if(typeOfItem==itemType.shieldBlocks)
        {
            mainController.GetComponent<LevelController>().activateShields();
        }
    }

}
