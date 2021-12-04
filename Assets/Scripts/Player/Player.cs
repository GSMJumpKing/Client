using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float walkSpeed;
    private float moveInput;
    public bool isGrounded;
    public bool isGrounded2;
    public bool isClose;
    private Rigidbody2D rigid;
    public Animator anim;
    public LayerMask groundMask;
    public float maxJumpPower;


    public SpriteRenderer sp;
    public PhysicsMaterial2D bounceMat, normalMat;
    public bool isWalk;
    public bool canJump = true;
    public bool isSleep = false;
    public float jumpValue = 0f;

    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Movement();
        
        animationControl();
    }

    private void FixedUpdate()
    {


        isGrounded = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y),
            new Vector2(0.72f, 0.4f), 0f, groundMask);

        isClose = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.21f),
            new Vector2(0.72f, 0.5f), 0f, groundMask);

        if (isClose || rigid.velocity.y <= -50f)
        {
            rigid.sharedMaterial = normalMat;
        }
        else
        {
            rigid.sharedMaterial = bounceMat;
        }

        
        if (isGrounded && isSleep)
        {
            anim.SetTrigger("Sleep");
            isSleep = false;
        }
        /*if (rigid.velocity.y > 0)
        {
            rigid.sharedMaterial = bounceMat;
        }
        else
        {
            rigid.sharedMaterial = normalMat;
        }*/
       

        if(rigid.velocity.y <= -26f)
        {
            isSleep = true;
        }
    }


    void Movement()
    {
        if (!GSManager.Instance.isEnd)
        {
            if (isGrounded)
            {
                moveInput = Input.GetAxisRaw("Horizontal");
            }

            if (moveInput == -1)
            {
                sp.flipX = true;
            }
            else if (moveInput == 1)
            {
                sp.flipX = false;
            }

            if (jumpValue == 0f && isGrounded)
            {
                rigid.velocity = new Vector2(moveInput * walkSpeed, rigid.velocity.y);
            }

            if (Input.GetKeyDown("space") && isGrounded && canJump)
            {
                rigid.velocity = new Vector2(0f, rigid.velocity.y);
                anim.SetBool("isReady", true);
            }

            if (Input.GetKey("space") && isGrounded && canJump)
            {
                jumpValue += 0.3f;
            }

            if (jumpValue >= maxJumpPower && isGrounded)
            {
                float tx = moveInput * walkSpeed * 1.5f;
                jumpValue = maxJumpPower;
                float ty = jumpValue;
                rigid.velocity = new Vector2(tx, ty);
                anim.SetBool("isReady", false);

                Invoke("ResetJump", 0.2f);
            }

            if (Input.GetKeyUp("space"))
            {
                if (isGrounded)
                {
                    rigid.velocity = new Vector2(moveInput * walkSpeed * 1.5f, jumpValue);
                    jumpValue = 0;
                    anim.SetBool("isReady", false);

                }
                canJump = true;
            }

        }
    }

    void ResetJump()
    {
        canJump = false;
        jumpValue = 0;
    }

    void animationControl()
    {
        //anim.SetBool("Walk", isWalk);
        anim.SetBool("isGrounded", isGrounded);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y),
            new Vector2(0.72f, 0.4f));
    }


}
    