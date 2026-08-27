using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseWeak : MonoBehaviour
{
    public int health;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Projectile"))
        {
            health--;
        }
    }
}
