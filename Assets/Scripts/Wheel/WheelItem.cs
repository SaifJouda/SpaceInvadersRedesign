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
            PlayerPrefs.SetInt("HP_Powerup", PlayerPrefs.GetInt("HP_Powerup") + 1);

        }
        else if(typeOfItem==wheelItem.doubleTap)
        {
            itemText.text = "+1 Double Tap";
            PlayerPrefs.SetInt("MS_Powerup", PlayerPrefs.GetInt("MS_Powerup") + 1);

        }
        else if(typeOfItem==wheelItem.time)
        {
            itemText.text = "+1 Time Freeze";
            PlayerPrefs.SetInt("TF_Powerup", PlayerPrefs.GetInt("TF_Powerup") + 1);

        }
        else if(typeOfItem==wheelItem.coin1)
        {
            itemText.text = "+100 Coin";
            PlayerPrefs.SetInt("Credits", PlayerPrefs.GetInt("TF_Powerup") + 100);
        }
        else if(typeOfItem==wheelItem.coin2)
        {
            itemText.text = "+250 Coin";
            PlayerPrefs.SetInt("Credits", PlayerPrefs.GetInt("TF_Powerup") + 250);

        }
        else if(typeOfItem==wheelItem.coin3)
        {
            itemText.text = "+500 Coin";
            PlayerPrefs.SetInt("Credits", PlayerPrefs.GetInt("TF_Powerup") + 500);

        }
        else if(typeOfItem==wheelItem.coin4)
        {
            itemText.text = "+1000 Coin";
            PlayerPrefs.SetInt("Credits", PlayerPrefs.GetInt("TF_Powerup") + 1000);

        }

    }

}
