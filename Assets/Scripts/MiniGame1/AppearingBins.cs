using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearingBins : MonoBehaviour
{
    public GameObject bin;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            bin.gameObject.SetActive(true);
        }
    }
}
