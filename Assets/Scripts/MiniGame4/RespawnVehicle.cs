using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnVehicle : MonoBehaviour
{

    private Vector2 startPos;
    private float startRotation;
    public GameObject playerVehicle;

    private Rigidbody2D rb;
    void Start()
    {
        startPos = playerVehicle.transform.position;
        startRotation = playerVehicle.transform.eulerAngles.z;

        rb = playerVehicle.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision) // you can reference it to the progress bar in gamemanager if you do decide to
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerVehicle.transform.position = startPos;
            playerVehicle.transform.rotation = Quaternion.Euler(0, 0, startRotation);

            rb.angularVelocity = 0f;
        }
    }
}
