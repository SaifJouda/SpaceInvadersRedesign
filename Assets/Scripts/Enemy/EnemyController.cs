using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    float speed = 1.0f;
    int steps = 16;
    Rigidbody2D rigidbody2d;
    int stepCounter=8;
    int horizontal=1;

    private float moveCooldown = 0.5f;
    float moveCooldownTimer;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        moveCooldownTimer=moveCooldown;
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
                position.x = position.x + speed * horizontal;
                stepCounter++;
            }
            else
            {
                position.y = position.y + speed * -1;
                stepCounter=0;
                horizontal*=-1;
            }
            moveCooldownTimer=moveCooldown;
            rigidbody2d.MovePosition(position);
        }
    }
}
