using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace freddie
{
    public class FreddieBrickBeh : MonoBehaviour
    {
        // Uses enum to track the 3 possible brick states.
        public enum BrickState { Moving, Falling, Stopped };
        public BrickState brickState;

        public Rigidbody2D rb;

        // Allows alternating movements for the brick on top.
        public float movingSpeed;
        public Vector3 hoverPosL;
        public Vector3 hoverPosR;

        // True to move left, false to move right.
        public bool moveLeftOrRight;

        // REMOVE WHEN GAMEMANAGER IS THERE.    
        void Start()
        {
            Application.targetFrameRate = 60;
        }
        void Awake()
        {
            brickState = BrickState.Moving;
        }

        void Update()
        {
            // Freezes the Y axis to move around left and right.
            if (brickState == BrickState.Moving)
            {
                rb.constraints = RigidbodyConstraints2D.FreezePosition;

                if (moveLeftOrRight)
                {
                    transform.localPosition = Vector3.MoveTowards(transform.localPosition, hoverPosL, movingSpeed);
                    if (transform.localPosition == hoverPosL) moveLeftOrRight = false;
                }
                else
                {
                    transform.localPosition = Vector3.MoveTowards(transform.localPosition, hoverPosR, movingSpeed);
                    if (transform.localPosition == hoverPosR) moveLeftOrRight = true;
                }

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    brickState = BrickState.Falling;
                }
            }

            // Unfreezes the Y axis and freezes the X axis as it is falling.
            if (brickState == BrickState.Falling)
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
            if (collision.CompareTag("Brick"))
            {
                brickState = BrickState.Stopped;
            }
        }
    }
}