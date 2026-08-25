using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabSpawner : MonoBehaviour
{
    public GameObject projectile;

    // Area which the game can spawn objects, play around with caution as some tabs can go out of bounds
    public float distanceLimitX;
    public float distanceLimitY;

    // Spawn Cooldown
    public float spawningCooldown;
    public bool canSpawn;

    // Spawn Limit (incase we don't use a timer for this one)
    public int spawnsLeft;
    public bool spawnLimitReached;

    void Start()
    {
        canSpawn = true;
    }
    
    void Update()
    {
        // Spawns tabs until they can't anymore.
        if(canSpawn && !spawnLimitReached) 
        {
            spawnsLeft--;
            Instantiate(projectile, new Vector3(transform.position.x + Random.Range(distanceLimitX,-distanceLimitX), transform.position.y + Random.Range(distanceLimitY,-distanceLimitY),0), Quaternion.identity);
            StartCoroutine(Spawn());
        }
        if (spawnsLeft < 1) spawnLimitReached = true;
    }
    
    IEnumerator Spawn()
    {
        canSpawn = false;
        yield return new WaitForSeconds(spawningCooldown);
        canSpawn = true;
    }
}
