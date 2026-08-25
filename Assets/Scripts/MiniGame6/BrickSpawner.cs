using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    // Tracks bricks
    public GameObject brick;
    public GameObject currentBrick;

    // Spawn Limit (incase we don't use a timer for this one)
    public int spawnsLeft;
    public bool spawnLimitReached;
    public bool canSpawn;
    
    void Update()
    {
        // Spawns bricks until they can't anymore.
        if(!spawnLimitReached && canSpawn) 
        {
            spawnsLeft--;
            currentBrick = Instantiate(brick,transform.position, Quaternion.identity);
            canSpawn = false;
        }
        if (currentBrick.GetComponent<BrickBehaviour>().brickState == BrickBehaviour.BrickState.Stopped)
        {
            canSpawn = true;
        }

        if (spawnsLeft < 1) spawnLimitReached = true;
    }
}
