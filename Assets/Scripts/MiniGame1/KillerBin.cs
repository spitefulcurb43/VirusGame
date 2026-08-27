using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerBin : MonoBehaviour
{

    private Vector2 startPos;
    public GameObject player;  

    // for when the player dies, they lose a bit of progress on the progress bar (for freddie)

    void Awake()
    {
        startPos = new Vector2(-12.1f, -6.8f);
    }
    public void ResetPosition()
    {
        player.transform.position = startPos;  

        Rigidbody2D rb2D = player.GetComponent<Rigidbody2D>();
        if(rb2D != null)
        {
            rb2D.velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ResetPosition();
        }
    }
}
