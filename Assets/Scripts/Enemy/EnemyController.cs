using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    float speedX = 1.0f;
    public float speedY=1.0f;
    int steps = 8;
    Rigidbody2D rigidbody2d;
    int stepCounter=4;
    int horizontal=1;

    private float moveCooldown = 0.5f;
    float moveCooldownTimer;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        moveCooldownTimer=moveCooldown;
        player=GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        moveCooldownTimer -= Time.deltaTime;
        if (moveCooldownTimer <= 0)
        {
            if(stepCounter<steps)
            {
                position.x = position.x + speedX * horizontal;
                stepCounter++;
            }
            else
            {
                position.y = position.y + speedY * -1;
                stepCounter=0;
                horizontal*=-1;
            }
            moveCooldownTimer=moveCooldown;
            rigidbody2d.MovePosition(position);
        }
        if(transform.position.y <=-6)
        {
            player.GetComponent<PlayerDamageController>().ChangeHealth(-10);
        }
    }
}
