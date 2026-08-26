using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabAttacker : MonoBehaviour
{
    public GameObject target;
    public GameObject projectile;
    public float runSpeed;

    void Start()
    {
        target = GameObject.Find("ProtectionObjective");
    }
    
    // Flys towards the protection objective at a high speed
    void Update()
    {
        Vector2 projectileVec2 = projectile.transform.position;
        Vector2 targetPos= target.transform.position;

        projectile.GetComponent<Rigidbody2D>().AddForce(1/3f * runSpeed * (targetPos - projectileVec2)/(targetPos - projectileVec2).magnitude);
    }

    // Destroys projectile if it comes to an important object and deals damage to the protection objective.
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("DestroyProjectile"))
        {
            Destroy(gameObject);
        }
        else if(collision.CompareTag("ProtectionObjective"))
        {
            collision.GetComponent<ProtectionObjective>().health--;
            Destroy(gameObject);
        }
    }
}
