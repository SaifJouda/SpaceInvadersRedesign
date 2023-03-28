using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WheelItem : MonoBehaviour
{
    public enum wheelItem {heal, doubleTap, time, coin1, coin2, coin3, coin4};   
    public wheelItem typeOfItem;
    public TMP_Text itemText;

    public void Reward()
    {
        if(typeOfItem==wheelItem.heal)
        {
            itemText.text = "+1 Heal";
            //add heal
        }
        else if(typeOfItem==wheelItem.doubleTap)
        {
            itemText.text = "+1 Double Tap";
            //add doubletap
        }
        else if(typeOfItem==wheelItem.time)
        {
            itemText.text = "+1 Time Freeze";
            //add time freeze powerup
        }
        else if(typeOfItem==wheelItem.coin1)
        {
            itemText.text = "+1 Coin";
            //add money
        }
        else if(typeOfItem==wheelItem.coin2)
        {
            itemText.text = "+2 Coin";
            //add money
        }
        else if(typeOfItem==wheelItem.coin3)
        {
            itemText.text = "+3 Coin";
            //add money
        }
        else if(typeOfItem==wheelItem.coin4)
        {
            itemText.text = "+4 Coin";
            //add money
        }
       
    }

}
