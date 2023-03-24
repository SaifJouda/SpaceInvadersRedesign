using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{

    //Speed of ship
    public float speed = 15.0f;


    Rigidbody2D rigidbody2d;

    //For input component
    float horizontal;
    //float vertical;

    private KeyCode rightKeyCode;
    private KeyCode leftKeyCode;


    void Start()
    {
 
        rigidbody2d = GetComponent<Rigidbody2D>();

        if (!PlayerPrefs.HasKey("MoveRightKey"))
        {
            PlayerPrefs.SetString("MoveRightKey", KeyCode.D.ToString());
            PlayerPrefs.Save();
        }
        if (!PlayerPrefs.HasKey("MoveLeftKey"))
        {
            PlayerPrefs.SetString("MoveLeftKey", KeyCode.A.ToString());
            PlayerPrefs.Save();
        }

    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        //horizontal = Input.GetAxis("Horizontal");
        //vertical = Input.GetAxis("Vertical");

        
        rightKeyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("MoveRightKey"));
        leftKeyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("MoveLeftKey"));

        // interpolation for smooth movement
        if (Input.GetKey(leftKeyCode))
        {
            horizontal = Mathf.Lerp(horizontal, -1, 0.15f);
        }
        if (Input.GetKey(rightKeyCode))
        {
            horizontal = Mathf.Lerp(horizontal, 1, 0.15f);
        }
        if (!Input.GetKey(leftKeyCode) && !Input.GetKey(rightKeyCode))
        {
            horizontal = Mathf.Lerp(horizontal, 0, 0.15f);
        }
        

        rigidbody2d.velocity=new Vector2(speed*horizontal, 0);
    }

}
