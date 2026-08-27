using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DesktopProjectile : MonoBehaviour
{
    public bool availableForUse;
    public GameObject player;
    public GameObject explosion;
    // Set speed to low for homing, set it to high for initial rushes
    public float speed;
    public Rigidbody2D rb;

    /*
    Homes towards player at a fast speed
    */

    public bool attacking;
    public float lifetime;

    void Awake()
    {
        availableForUse = true;
        player = GameObject.Find("Player");
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    void Update()
    {
        if(attacking)
        {
            Vector2 projectileVec2 = transform.position;
            Vector2 targetPos = player.transform.position;

            rb.AddForce(speed * (targetPos - projectileVec2)/(targetPos - projectileVec2).magnitude);
        }
    }
    public void Trigger()
    {
        Destroy(gameObject,lifetime);
        rb.constraints = RigidbodyConstraints2D.None;
        availableForUse = false;
        attacking = true;
    }

    void OnDestroy()
    {
        explosion = Instantiate(explosion, transform.position, transform.rotation);
        Destroy(explosion,0.75f);
    }
}
