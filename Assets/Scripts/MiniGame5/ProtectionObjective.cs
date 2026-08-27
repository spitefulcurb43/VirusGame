using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectionObjective : MonoBehaviour
{
    public int health;

    void Update()
    {
        if(health < 1)
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
