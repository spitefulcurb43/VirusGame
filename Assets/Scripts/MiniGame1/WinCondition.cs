using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public GameObject trollPlatformer;

    // and then when you win 10% or sum in the progress bar (for freddie)

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            trollPlatformer.gameObject.SetActive(false);
        }
    }
}
