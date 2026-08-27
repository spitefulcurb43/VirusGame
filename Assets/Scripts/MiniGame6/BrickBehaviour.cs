using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBehaviour : MonoBehaviour
{
    // Uses enum to track the 3 possible brick states.
    public enum BrickState{Idle, Moving, Falling, Stopped};
    public BrickState brickState;
    public BrickSpawner brickSpawner;
    

    // Idle time before it is allowed to drop
    public float idleTime;

    public Rigidbody2D rb;

    // Allows alternating movements for the brick on top.
    public float movingSpeed;
    public Vector3 hoverPosL;
    public Vector3 hoverPosR;

    // True to move left, false to move right.
    public bool moveLeftOrRight;

    public bool endReached;

    // REMOVE WHEN GAMEMANAGER IS THERE.    
    void Start()
    {
        Application.targetFrameRate = 60;
    }
    void Awake()
    {
        brickState = BrickState.Moving;
        
        // Prevents instant drops
        StartCoroutine(EnableDrop());
    }

    void Update()
    {
        // Freezes the Y axis to move around left and right.
        if(brickState == BrickState.Moving || brickState == BrickState.Idle)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePosition;

            if(moveLeftOrRight) 
            {
                transform.position = Vector3.MoveTowards(transform.position, hoverPosL, movingSpeed);
                if (transform.position == hoverPosL) moveLeftOrRight = false;
            }
            else 
            {
                transform.position = Vector3.MoveTowards(transform.position, hoverPosR, movingSpeed);
                if (transform.position == hoverPosR) moveLeftOrRight = true;
            }

            if(Input.GetKeyDown(KeyCode.Space) && brickState == BrickState.Moving)
            {
                brickState = BrickState.Falling;
            }
        }

        // Unfreezes the Y axis and freezes the X axis as it is falling.
        if(brickState == BrickState.Falling)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        }
        
        // Freezes all axes when the object lands in its desired spot.
        if (brickState == BrickState.Stopped)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Brick"))
        {
            brickState = BrickState.Stopped;
            brickSpawner.stacked++;
        }

        if(collision.CompareTag("DestroyProjectile"))
        {
            brickState = BrickState.Stopped;
            Destroy(gameObject);
        }

        if(collision.CompareTag("Exit") && brickState == BrickState.Stopped)
        {
            endReached = true;
        }
    }

    IEnumerator EnableDrop()
    {
        yield return new WaitForSeconds(idleTime);
        brickState = BrickState.Moving;
    }
}
