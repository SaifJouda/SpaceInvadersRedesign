using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyController : MonoBehaviour
{
    public float enemyMoveSpeed=1;
    private float enemyMoveSpeedSave=1;
    bool slowSpeed = false;
    float slowSpeedRemaining=0f;
    // Start is called before the first frame update
    void Start()
    {
        //enemyMoveSpeed=1;
    }

    void Update()
    {
        if(slowSpeed)
        {
            slowSpeedRemaining-= Time.deltaTime;
            if(slowSpeedRemaining<=0)
            {
                slowSpeed=false;
                enemyMoveSpeed=enemyMoveSpeedSave;
            }
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            slowModeOn();
        }
    }

    public void changeMoveSpeed(float i)
    {
        slowSpeed=false;
        slowSpeedRemaining=0;
        enemyMoveSpeed=i;
        enemyMoveSpeedSave=i;
    }

    public void slowModeOn()
    {
        slowSpeed=true;
        slowSpeedRemaining=4f;
        enemyMoveSpeed=0.5f;
    }

    
}
