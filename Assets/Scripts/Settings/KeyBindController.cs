using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class KeyBindController : MonoBehaviour
{
    public TextMeshProUGUI shootButton;
    public TextMeshProUGUI mvRightButton;
    public TextMeshProUGUI mvLeftButton;

    public GameObject shootButtonPlaceholder;
    public GameObject mvRightButtonPlaceholder;
    public GameObject mvLeftButtonPlaceholder;

    public GameObject inputBlocker;

    private bool changeShootKey;
    private bool changeMoveRightKey;
    private bool changeMoveLeftKey;

    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("ShootKey"))
        {
            PlayerPrefs.SetString("ShootKey", KeyCode.Space.ToString());
            PlayerPrefs.Save();
        }
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

        shootButton.text = PlayerPrefs.GetString("ShootKey");
        mvRightButton.text = PlayerPrefs.GetString("MoveRightKey");
        mvLeftButton.text = PlayerPrefs.GetString("MoveLeftKey");

        changeShootKey = false;
        changeMoveRightKey = false;
        changeMoveLeftKey = false;
    }

    // Update is called once per frame
    void Update()
    {
        AwaitShootKey();
        AwaitMoveRightKey();
        AwaitMoveLeftKey();
    }

    public void ChangeShootKey()
    {
        if (!changeMoveRightKey && !changeMoveLeftKey)
        changeShootKey = true;
    }
    private void AwaitShootKey()
    {
        if (changeShootKey)
        {
            shootButton.text = "";

            foreach (KeyCode keycode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(keycode))
                {
                    if (!String.Equals(keycode.ToString(), PlayerPrefs.GetString("MoveRightKey")) && !String.Equals(keycode.ToString(), PlayerPrefs.GetString("MoveLeftKey")))
                    {
                        shootButton.text = keycode.ToString();
                        PlayerPrefs.SetString("ShootKey", keycode.ToString());
                        PlayerPrefs.Save();
                    }
                    else
                    {
                        shootButton.text = PlayerPrefs.GetString("ShootKey");
                    }
                    shootButtonPlaceholder.SetActive(false);
                    inputBlocker.SetActive(false);
                    changeShootKey = false;
                }
            }
        }
    }

    public void ChangeMoveRightKey()
    {
        if (!changeShootKey && !changeMoveLeftKey)
            changeMoveRightKey = true;
    }
    private void AwaitMoveRightKey()
    {
        if (changeMoveRightKey)
        {
            mvRightButton.text = "";

            foreach (KeyCode keycode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(keycode))
                {
                    if (!String.Equals(keycode.ToString(), PlayerPrefs.GetString("ShootKey")) && !String.Equals(keycode.ToString(), PlayerPrefs.GetString("MoveLeftKey")))
                    {
                        mvRightButton.text = keycode.ToString();
                        PlayerPrefs.SetString("MoveRightKey", keycode.ToString());
                        PlayerPrefs.Save();
                    }
                    else
                    {
                        mvRightButton.text = PlayerPrefs.GetString("MoveRightKey");
                    }
                    mvRightButtonPlaceholder.SetActive(false);
                    inputBlocker.SetActive(false);
                    changeMoveRightKey = false;
                }
            }
        }
    }

    public void ChangeMoveLeftKey()
    {
        if (!changeShootKey && !changeMoveRightKey)
            changeMoveLeftKey = true;
    }
    private void AwaitMoveLeftKey()
    {
        if (changeMoveLeftKey)
        {
            mvLeftButton.text = "";

            foreach (KeyCode keycode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(keycode))
                {
                    if (!String.Equals(keycode.ToString(), PlayerPrefs.GetString("ShootKey")) && !String.Equals(keycode.ToString(), PlayerPrefs.GetString("MoveRightKey")))
                    {
                        mvLeftButton.text = keycode.ToString();
                        PlayerPrefs.SetString("MoveLeftKey", keycode.ToString());
                        PlayerPrefs.Save();
                    }
                    else
                    {
                        mvLeftButton.text = PlayerPrefs.GetString("MoveLeftKey");
                    }
                    mvLeftButtonPlaceholder.SetActive(false);
                    inputBlocker.SetActive(false);
                    changeMoveLeftKey = false;
                }
            }
        }
    }
}
