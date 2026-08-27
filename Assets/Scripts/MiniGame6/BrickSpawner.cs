using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    // Tracks bricks
    public GameObject brick;
    public GameObject webBrick;
    public GameObject currentBrick;

    // Spawn Limit (incase we don't use a timer for this one)
    public int spawnsLeft;
    public bool spawnLimitReached;
    public bool canSpawn;

    // Stacks until a limit where a special brick with the website link can spawn
    public int stacked;
    public int limit;
    
    void Update()
    {
        // Spawns bricks until they can't anymore.
        if(!spawnLimitReached && canSpawn) 
        {
            spawnsLeft--;
            if (stacked == limit - 1) currentBrick = Instantiate(webBrick,transform.position, Quaternion.identity);
            else currentBrick = Instantiate(brick,transform.position, Quaternion.identity);
            currentBrick.GetComponent<BrickBehaviour>().brickSpawner = GetComponent<BrickSpawner>();
            canSpawn = false;
        }
        if (currentBrick.GetComponent<BrickBehaviour>().brickState == BrickBehaviour.BrickState.Stopped)
        {
            canSpawn = true;
        }

        if (spawnsLeft < 1) 
        {
            spawnLimitReached = true;

            if (currentBrick.GetComponent<BrickBehaviour>().endReached)
            {
                // CALLS GAMEMANAGER TO ENABLE WEBSITE LINK BUTTON
            }
            else
            {
                // CALLS GAMEMANAGER TO LOSE
            }
        }
    }
}
