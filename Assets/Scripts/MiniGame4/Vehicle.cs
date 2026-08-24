using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    public GameManager gameManager;

    // Physics
    public Rigidbody2D rb;
    public bool stopped;

    // Movement
    public float bonusSpeed;
    public float speedLimit;
    public bool isMoving;

    // Rotation
    public bool isRotating;
    public float rotation;
    public float bonusRotateSpeed;

    // Directions
    public float horizontal;
    public float vertical;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    // DONT TOUCH THIS PLEASE I REALLY DONT KNOW WHAT THIS DOES ANYMORE
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)) 
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) 
            {
                isRotating = true;
                transform.Rotate(0, 0, rotation * -horizontal * Time.fixedDeltaTime * bonusRotateSpeed);
            }
            isMoving = true;
            if (rb.velocity.x < speedLimit && rb.velocity.x > -speedLimit) 
            {
                if (vertical == -1) rb.AddForce(vertical * 0.8f * bonusSpeed * transform.up);
                else rb.AddForce(vertical * bonusSpeed * transform.up);
            }
        }

        if (vertical == 0)
        {
            isMoving = false;
        }

        if (horizontal == 0)
        {
            isRotating = false;
        }

        if (!isMoving && !isRotating)
        {
            rb.drag = 6f;
        }
        else if (isRotating)
        {
            rb.drag = 2f;
        }
        else
        {
            rb.drag = 1/3f;
        }

        if (Math.Abs(rb.velocity.x) < 0.1f && Math.Abs(rb.velocity.y) < 0.1f)
        {
            stopped = true;
        }
        else
        {
            stopped = false;
        }
    }
}
