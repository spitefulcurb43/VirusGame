using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class ProtectionObjective : MonoBehaviour
{
    public int health;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            LoseGame();
        }
    }
    void LoseGame()
    {
        Debug.Log("You lose!");
    }

}
