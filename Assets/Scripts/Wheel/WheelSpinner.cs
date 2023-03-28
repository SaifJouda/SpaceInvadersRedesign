using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WheelSpinner : MonoBehaviour
{
    float rotSpeed=0;
    float slowRate=0;
    public Transform hitPoint;
    public LayerMask itemLayers;
    public float hitRange;
    private bool spinnerLand=false;
    public GameObject popup;
    public TMP_Text spinsLeftTxt;
    private int spinsLeft;
    private bool spinning=false;

    void Start()
    {
        spinning=false;
        spinsLeft=1;
        spinsLeftTxt.text = "Spins: "+ spinsLeft.ToString();
    }

    void FixedUpdate()
    {
        if(rotSpeed>0.01f)
            rotSpeed*=slowRate;
        else
        {
            rotSpeed=0;
            spinning=false;
            if(spinnerLand==true)
            {
                spinnerLand=false;
                Land();
            }
        }
            
        transform.Rotate(0,0,rotSpeed);
    }


    public void Spin()
    {
        if(spinsLeft>0 && spinning==false)
        {
            spinning=true;
            rotSpeed=Random.Range(50,150);
            slowRate=1f-Random.Range(0.005f,0.06f);
            spinnerLand=true;
            spinsLeft-=1;
            spinsLeftTxt.text = "Spins: "+ spinsLeft.ToString();
        }

    }

    public void Land()
    {
        Collider2D[] hitItems = Physics2D.OverlapCircleAll(hitPoint.position, hitRange, itemLayers);

        //Damage
        if(hitItems.Length>0)
        {
            hitItems[0].GetComponent<WheelItem>().Reward();
            popup.SetActive(true);
            Debug.Log(hitItems[0].GetComponent<WheelItem>().typeOfItem);

            //wheelItem typeOfItem;
            //typeof(WheelItem.wheelItem) enumType;// = typeof(WheelItem.wheelItem);
            //Type enumType = typeof(WheelItem);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(hitPoint.position,hitRange);
    }

   
}
