using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDamageController : MonoBehaviour
{
    //General Stats
    public int maxHealth = 1;
    public int currentHealth;
    public UnityEvent OnDead;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            ChangeHealth(-1);
        }
    }

    public void ChangeHealth(int amount)
    {
        if(currentHealth<=0)
            return;

        currentHealth +=amount;

        if(currentHealth<=0)
        {
            //Die();
            OnDead?.Invoke();
        }

    }
}
