using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private LayerMask PlatformLayerMask;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    [SerializeField]private int lastWallSide;

    [SerializeField] private float gravityAttaWall;
    [SerializeField] private float gravityNormal;
    private int maxJumpCount = 1;
    private BoxCollider2D boxCollider;
    [SerializeField] private int jumpCount;
    private Rigidbody2D rb;
    [SerializeField] bool canMoveRight, canMoveLeft;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0) Move();
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 0) Jump();
        if (isGrounded())
        {
            jumpCount = maxJumpCount;
            lastWallSide = 0;
        }
        isAttachedWall();

    }

    void Move()
    {
        float moveDirection = Input.GetAxis("Horizontal");
        if(moveDirection > 0 && canMoveRight)
            rb.velocity = new Vector2(moveDirection * speed * Time.fixedDeltaTime, rb.velocity.y);
        if(moveDirection < 0 && canMoveLeft)
            rb.velocity = new Vector2(moveDirection * speed * Time.fixedDeltaTime, rb.velocity.y);

    }
    bool isGrounded()
    {
        Vector2 size = new Vector2(boxCollider.bounds.size.x - 0.25f, boxCollider.bounds.size.y);
        float colliderHeight = 0.1f;
        RaycastHit2D raycastHit = Physics2D.BoxCast
            (boxCollider.bounds.center, size, 0f,
             Vector2.down, colliderHeight, PlatformLayerMask);
        return raycastHit;
    }
    void isAttachedWall()
    {
        float colliderWidth = 0.01f;
        RaycastHit2D raycastHitL = Physics2D.BoxCast
            (boxCollider.bounds.center, boxCollider.bounds.size, 0f,
             Vector2.left, colliderWidth, PlatformLayerMask);
        RaycastHit2D raycastHitR = Physics2D.BoxCast
            (boxCollider.bounds.center, boxCollider.bounds.size, 0f,
             Vector2.right, colliderWidth, PlatformLayerMask);

        if (raycastHitL.distance > 0) AttachedWallRestraints("Left");

        else if (raycastHitR.distance > 0) AttachedWallRestraints("Right");

        else AttachedWallRestraints("None");

    }
    void AttachedWallRestraints(string side)
    {
        switch (side)
        {
            case "Left":
                {
                    if (lastWallSide == 1) jumpCount = maxJumpCount;
                    canMoveLeft = false;
                    lastWallSide = -1;
                    break;
                }
            case "Right":
                {
                    if (lastWallSide == -1) jumpCount = maxJumpCount;
                    canMoveRight = false;
                    lastWallSide = 1;
                    break;
                }
            case "None":
                {
                    canMoveLeft = true;
                    canMoveRight = true;
                    break;
                }
        }
        if ((!canMoveLeft || !canMoveRight) && rb.velocity.y < 0) rb.gravityScale = gravityAttaWall;
        else rb.gravityScale = gravityNormal;
    }
    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce * Time.fixedDeltaTime);
        jumpCount--;
        
    }
}
