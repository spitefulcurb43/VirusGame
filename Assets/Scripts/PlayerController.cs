using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /*// Required for level reset
    public GameManager GameManager;
    public Vector3 initPos;
    */

    // Sprite
    public SpriteRenderer spriteRenderer;

    // Physics components
    public Rigidbody2D rb;
    public CapsuleCollider2D collision;

    // Platformer basics
    public float speed;
    public float jumpPower;

    // Coyote Time
    public float coyoteTime;
    public float coyoteTimeCounter;

    // Jump Buffering
    public float jumpBufferTime;
    public float jumpBufferCounter;

    // Ground check
    public float checkDistance;

    // Other Layers (Note: Importing Scripts will break this sometimes so make sure to update this to your unity project!!!)
    public LayerMask goodLayer;
    public LayerMask badLayer;
    public LayerMask groundLayer;
    
    void Start()
    {
        // Disables rigidbody before continuing
        collision = GetComponent<CapsuleCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        //setting defaults
        speed = 5f;
        jumpPower = 8.5f;

        coyoteTime = 0.2f;
        jumpBufferTime = 0.2f;
        checkDistance = 0.05f;
    }

    void Update()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = Input.GetAxisRaw("Horizontal") * speed; //GetAxisRaw is -1, 0 or 1

        // Resets coyote time if it is on the ground
        // Otherwise, reduce coyote time (disables jump if the player has too much air time)
        if (CheckIsGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        // Pressing space resets jump variables to enable a jump.
        // Not pressing space decreases jump buffer which makes it less strict on whether the player is on the ground yet for a smoother experience.
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (rb.velocity.y > 0f)
            {
                coyoteTimeCounter = 0f;
            }
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        // If the player press space bar while not jumping and not already falling past coyote time:
        // This part of the code makes the player jump and triggers a cooldown, as the jump power is applied instantly.
        if (coyoteTimeCounter > 0f && jumpBufferCounter > 0f)
        {
            velocity.y = jumpPower;
            jumpBufferCounter = 0f;
        }

        // Applies the velocity change
        rb.velocity = velocity;


        if (rb.velocity.x > 0f) spriteRenderer.flipX = false;
        if (rb.velocity.x < 0f) spriteRenderer.flipX = true;
    }

    bool CheckIsGrounded()
    {
        // Fires a "ray" that travels from the player downwards with the checkDistance looking for any gameObject with the ground layer mask.
        return Physics2D.CapsuleCast(transform.position, transform.localScale, CapsuleDirection2D.Vertical, 0f, -transform.up, checkDistance, groundLayer);
    }


    /*
    WIN/LOSE CONDITION
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & goodLayer) != 0)
        {
            GameManager.gameState = GameManager.GameState.win;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        if (((1 << collision.gameObject.layer) & badLayer) != 0)
        {
            GameManager.gameState = GameManager.GameState.lose;
        }
    }
    */
}
