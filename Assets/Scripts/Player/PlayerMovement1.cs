using UnityEngine;
using System;

public class PlayerMovement1 : DefaultMovement
{
    public float jumpForce;         // Amount of force added when the player jumps.
    public PlayerHealth PlayerHealthInstance;

    private Transform groundCheck;
    private bool jump = false;
    private bool canDoubleJump = false;
    private bool doubleJump = false;
    private bool grounded = false;
    private bool click = false;

    protected override void Awake()
    {
        base.Awake();
        //ground check do personagem
        groundCheck = transform.Find("groundCheck");
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        //if (canMove && Input.GetButtonDown("Jump") && grounded)
        //{
        //    jump = true;
        //    //Varia
        //    doubleJump = false;
        //    canDoubleJump = false;
        //}
        //if (canMove && Input.GetButtonDown("Jump") && canDoubleJump)
        //    doubleJump = true;
    }

    protected override float getAxis()
    {
        return Input.GetAxis("Horizontal");
    }

    protected override void FixedUpdate()
    {
        //Chama o fixed update
        base.FixedUpdate();
        //Se puder pular
        if (jump)
        {
            // Set the Jump animator trigger parameter.
            anim.SetTrigger("Jump");
            // Add a vertical force to the player.
            rgd2D.AddForce(new Vector2(0f, jumpForce));
            //Double jump
            canDoubleJump = true;
            // Make sure the player can't jump again until the jump conditions from Update are satisfied.
            jump = false;
        }
        //Se puder o double jump
        if (doubleJump)
        {
            //Seta para false o double jump
            canDoubleJump = false;
            doubleJump = false;
            // Set the Jump animator trigger parameter.
            anim.SetTrigger("Jump");
            rgd2D.AddForce(new Vector2(0f, jumpForce));
        }
    }
}