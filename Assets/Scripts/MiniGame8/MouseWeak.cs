using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseWeak : MonoBehaviour
{
    public int health;

    void Update()
    {
        if(health == 0)
        {
            // CALLS GAMEMANAGER TO LOSE
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Projectile"))
        {
            health--;
        }
    }
}
