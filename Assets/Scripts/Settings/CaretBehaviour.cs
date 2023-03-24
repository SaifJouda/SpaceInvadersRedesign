using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaretBehaviour : MonoBehaviour
{
    public GameObject CaretText;

    void OnEnable()
    {
        StartCoroutine(BlinkCaret());
    }

    IEnumerator BlinkCaret()
    {
        while (true)
        {
            CaretText.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            CaretText.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
