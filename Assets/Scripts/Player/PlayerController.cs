using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //Speed of ship
    public float speed = 15.0f;


    Rigidbody2D rigidbody2d;

    //For input component
    float horizontal; 
    //float vertical;
    
    void Start()
    {
 
        rigidbody2d = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        //vertical = Input.GetAxis("Vertical");

        rigidbody2d.velocity=new Vector2(speed*horizontal, 0);
    }

}
