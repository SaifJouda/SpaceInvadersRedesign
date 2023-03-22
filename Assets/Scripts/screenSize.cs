using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenSize : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int screenWidth = Screen.width;
        int screenHeight = Screen.height;
        Debug.Log(screenWidth);
        Debug.Log(screenHeight);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
