using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilitiesOrStartMenuProjectile : MonoBehaviour
{
    public bool availableForUse;
    public GameObject player;
    public GameObject explosion;

    // Set speed to low for homing, set it to high for initial rushes
    public float speed;
    public Rigidbody2D rb;

    public float lifetime;

    /*
    Fires at the player first on enable
    Explodes at a larger radius
    */
    

    void Awake()
    {
        availableForUse = true;
        player = GameObject.Find("Player");
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    public void Trigger()
    {
        Destroy(gameObject,lifetime);
        rb.constraints = RigidbodyConstraints2D.None;
        availableForUse = false;
        
        Vector2 projectileVec2 = transform.position;
        Vector2 targetPos = player.transform.position;

        rb.AddForce(speed * (targetPos - projectileVec2)/(targetPos - projectileVec2).magnitude);
    }

    void OnDestroy()
    {
        explosion = Instantiate(explosion, transform.position, transform.rotation);
        Destroy(explosion,0.75f);
    }
}
