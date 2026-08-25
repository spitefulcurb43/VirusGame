using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Key : MonoBehaviour
{
    public KeyCode keyCode;
    public bool scored;
    public float speed;
    public RhythmBar rhythmBar;

    void Awake()
    {
        rhythmBar = GameObject.Find("RhythmBar").GetComponent<RhythmBar>();
    }

    void Update()
    {
        transform.position += Vector3.left * speed;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("RhythmCheck") )
        {
            // Prevents accidental left clicks because I have to do it to open the scene
            if (!Input.anyKey || Input.GetMouseButton(0))
            {
                
            }
            // Wrong key "scores" 0/deals damage to the bar?
            else if (Input.anyKey && !Input.GetKey(keyCode))
            {
                print("FUCK");
                scored = true;
                rhythmBar.DamageBar();
                Destroy(gameObject);
            }
            // Getting the right key scores
            else
            {                
                print("Scored");
                scored = true;
                rhythmBar.ExtendBar();
                Destroy(gameObject);
            }
        }
    }

    // Passing check without input loses score
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("RhythmCheck") && !scored)
        {
            print("FUCK 2");
            rhythmBar.DamageBar();
            Destroy(gameObject);
        }
    }
}
