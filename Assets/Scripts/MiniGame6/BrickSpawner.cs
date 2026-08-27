using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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

    public Transform tallestBrick;
    public GameObject height;
    public GameObject floor;
    public GameObject bckg;
    public TextMeshPro scoreText;

    public int score = -2;

    private void Start()
    {
        scoreText.text = "Score: " + score;
        transform.localScale = new(1f / transform.lossyScale.x, 1f / transform.lossyScale.y);
    }

    void Update()
    {
        // Spawns bricks until they can't anymore.
        if(!spawnLimitReached && canSpawn) 
        {
            spawnsLeft--;
            currentBrick = Instantiate(brick, transform.position, Quaternion.identity, transform);
            canSpawn = false;
        }
        if (currentBrick.GetComponent<BrickBehaviour>().brickState == BrickBehaviour.BrickState.Stopped)
        {
            if (tallestBrick == null)
            {
                tallestBrick = currentBrick.transform;
                score++;
                scoreText.text = "Score: " + score;
            }

            if (currentBrick.transform.localPosition.y > tallestBrick.localPosition.y)
            {
                score++;
                scoreText.text = "Score: " + score;
                tallestBrick = currentBrick.transform;

                //Check to see if score = 0, if so lower the bottom.
                if(score >= 0)
                {
                    float brickHeight = brick.transform.lossyScale.y; //height of the brick

                    foreach(Transform kid in transform)
                    {
                        kid.transform.position -= Vector3.up * brick.transform.lossyScale.y;
                    }
                    floor.transform.position -= Vector3.up * brick.transform.lossyScale.y;
                    bckg.transform.position -= Vector3.up * brick.transform.lossyScale.y;
                }
            }

            canSpawn = true;
        }

        if(tallestBrick != null)
        {
            Vector2 idealPos = new(height.transform.position.x, tallestBrick.position.y);
            height.transform.position = Vector2.MoveTowards(height.transform.position, idealPos, Time.deltaTime * 15f);
        }

        if (spawnsLeft < 1) spawnLimitReached = true;
    }
}
