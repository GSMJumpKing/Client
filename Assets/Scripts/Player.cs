using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float walkSpeed;
    private float moveInput;
    public bool isGrounded;
    private Rigidbody2D rigid;
    public LayerMask groundMask;
    public float maxJumpPower;


    public PhysicsMaterial2D bounceMat, normalMat;
    public bool canJump = true;
    public float jumpValue = 0f;
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {



        Movement();

    }

    private void FixedUpdate()
    {


        isGrounded = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.5f),
            new Vector2(0.8f, 0.4f), 0f, groundMask);

        if (rigid.velocity.y > 0)
        {
            rigid.sharedMaterial = bounceMat;
        }
        else
        {
            rigid.sharedMaterial = normalMat;
        }
    }


    void Movement()
    {
        if (isGrounded)
        {
            moveInput = Input.GetAxisRaw("Horizontal");
        }

        if (jumpValue == 0f && isGrounded)
        {
            rigid.velocity = new Vector2(moveInput * walkSpeed, rigid.velocity.y);
        }

        if (Input.GetKeyDown("space") && isGrounded && canJump)
        {
            rigid.velocity = new Vector2(0f, rigid.velocity.y);
        }

        if (Input.GetKey("space") && isGrounded && canJump)
        {
            jumpValue += 1f;
        }

        if (jumpValue >= maxJumpPower && isGrounded)
        {
            float tx = moveInput * walkSpeed * 1.5f;
            float ty = jumpValue;
            rigid.velocity = new Vector2(tx, ty);
            Invoke("ResetJump", 0.2f);
        }

        if (Input.GetKeyUp("space"))    
        {
            if (isGrounded)
            {
                rigid.velocity = new Vector2(moveInput * walkSpeed * 1.5f, jumpValue);
                jumpValue = 0;
            }
            canJump = true;
        }
    }

    void ResetJump()
    {
        canJump = false;
        jumpValue = 0;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.5f),
            new Vector2(0.8f, 0.4f));
    }


}