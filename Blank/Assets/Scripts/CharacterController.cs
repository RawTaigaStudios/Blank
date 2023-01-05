using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Composites;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    [Header("Player Constraints")]
    
    [SerializeField] private LayerMask PlatformLayerMask;

    private BoxCollider2D boxCollider;
    private Rigidbody2D rb;


    [Header("Jump Constraints")]

    [SerializeField] private float jumpForce;
    [SerializeField] private float gravityAttaWall;
    [SerializeField] private float gravityNormal;
    [SerializeField] private int maxJumpCount = 2;
    [SerializeField] private float wallJumpMultiplier;
    [SerializeField] private float wallJumpTimer;
    [SerializeField] private AudioSource jumpSoundEffect; //prueba
    //[SerializeField] private AudioSource walkSoundEffect; //prueba


    private int jumpCount;
    private int lastWallSide;
    private float jumpTimer = .2f;
    private bool canCheckGround = true;

    [Header("Movement Constraints")]

    [SerializeField] bool canMoveRight, canMoveLeft;
    [SerializeField] private float speed;

    private Animator anim;

    [SerializeField] private PlayerInput inputs;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponentInChildren<Animator>();
        anim.SetBool("Wall", true);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (inputs.actions["Jump"].triggered && jumpCount > 0) Jump();
        if (isGrounded() && canCheckGround)
        {
            anim.SetBool("Grounded", true);
            jumpCount = maxJumpCount;
            lastWallSide = 0;
        }
        isAttachedWall();
    }
    private IEnumerator WallJump(string side)
    {
        inputs.actions[side].Disable();
        yield return new WaitForSeconds(wallJumpTimer);
        inputs.actions[side].Enable();
    }
    void Move()
    {
        
        float moveDirection = 0;
        if (inputs.actions["Right"].IsPressed() && !inputs.actions["Left"].triggered)
        {
            moveDirection = 1;
        }
        else if (inputs.actions["Left"].IsPressed() && !inputs.actions["Right"].triggered)
        {   
            moveDirection = -1;
        }
        else
        {
            moveDirection = 0;
        }
        
        if(moveDirection > 0 && canMoveRight)
        {
            anim.SetFloat("xVelocity", 1f);
            rb.velocity = new Vector2(moveDirection * speed * Time.fixedDeltaTime, rb.velocity.y);
        }
        if (moveDirection < 0 && canMoveLeft)
        {
            anim.SetFloat("xVelocity", -1f);
            rb.velocity = new Vector2(moveDirection * speed * Time.fixedDeltaTime, rb.velocity.y);
        }
        if (moveDirection == 0) anim.SetFloat("xVelocity", 0f);
    }
    bool isGrounded()
    {
        Vector2 size = new Vector2(boxCollider.bounds.size.x - 0.25f, boxCollider.bounds.size.y);
        float colliderHeight = 0.1f;
        RaycastHit2D raycastHit = Physics2D.BoxCast
            (boxCollider.bounds.center, size, 0f,
             Vector2.down, colliderHeight, PlatformLayerMask);
        try
        {
            if (!raycastHit.collider.gameObject.GetComponent<BoxCollider2D>().isTrigger)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        catch { }

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
                    if (lastWallSide == 1 || lastWallSide == 0)
                    {
                        jumpCount = 1;
                        
                    }
                    canMoveLeft = false;
                    lastWallSide = -1;
                    break;
                    
                }
            case "Right":
                {
                    if (lastWallSide == -1 || lastWallSide == 0)
                    {
                        jumpCount = 1;
                        
                    }
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
    IEnumerator JumpLapse()
    {
        canCheckGround = false;
        yield return new WaitForSeconds(jumpTimer);
        canCheckGround = true;
    }
    void Jump()
    {
        anim.SetBool("Grounded", false);
        anim.SetTrigger("Jump");
        if (!canMoveLeft)
        {
            jumpSoundEffect.Play();
            rb.AddForce(new Vector2(speed, jumpForce) * wallJumpMultiplier);
            //StartCoroutine(WallJump("Left"));
        }
        else if (!canMoveRight)
        {
            jumpSoundEffect.Play();
            rb.AddForce(new Vector2(-speed, jumpForce) * wallJumpMultiplier);
            //StartCoroutine(WallJump("Right"));
        }
        else
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce * Time.fixedDeltaTime);

        }
        jumpCount--;
        StartCoroutine(JumpLapse());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlatMov")
        {
            transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlatMov")
        {
            transform.parent = null;
        }
    }

}
