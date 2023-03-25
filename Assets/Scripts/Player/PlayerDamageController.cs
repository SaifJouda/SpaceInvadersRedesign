using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class PlayerDamageController : MonoBehaviour
{
    //General Stats
    public int maxHealth = 5;
    public int currentHealth;
    public UnityEvent OnDead;
    bool sheild=false;
    public GameObject shieldObject;
    public TMP_Text livesText;
    private GameObject mainController;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = 3;
        livesText.text=currentHealth.ToString();
        mainController=GameObject.Find("Main Controller");
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z)) ChangeHealth(1);

    }

    public void ChangeHealth(int amount)
    {
        if(currentHealth<=0)
            return;

        if(amount<0 && sheild==true)
        {
            amount++;
            sheild=false;
            shieldObject.SetActive(false);
        }

        currentHealth +=amount;
        if(currentHealth>maxHealth) currentHealth=maxHealth;

        if(currentHealth<=0)
        {
            //Die();
            if(currentHealth<0) currentHealth=0;
            OnDead?.Invoke();
            mainController.GetComponent<DifficultyController>().changeMoveSpeed(0.0001f);
        }
        livesText.text=currentHealth.ToString();

    }

    public void shieldOn()
    {
        shieldObject.SetActive(true);
        sheild=true;
    }
}
