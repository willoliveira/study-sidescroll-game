using UnityEngine;
using System.Collections;

public abstract class DefaultMovement : MonoBehaviour
{
    [HideInInspector]
    public bool facingRight = true;
    

    public float moveForce;
    public float maxSpeed;

    protected Rigidbody2D rgd2D;
    protected Animator anim;

    // Use this for initialization
    protected virtual void Awake()
    {
        anim = GetComponent<Animator>();
        rgd2D = GetComponent<Rigidbody2D>();
    }

    protected abstract float getAxis();    

    protected virtual void FixedUpdate()
    {
        // Cache the horizontal input.
        float h = getAxis();
        // The Speed animator parameter is set to the absolute value of the horizontal input.
        anim.SetFloat("Speed", Mathf.Abs(h));
        // If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
        if (Mathf.Abs(rgd2D.velocity.x) < maxSpeed)
        {
            // ... add a force to the player.
            rgd2D.AddForce(Vector2.right * h * moveForce, ForceMode2D.Force);
        }
        // If the player's horizontal velocity is greater than the maxSpeed...
        if (Mathf.Abs(rgd2D.velocity.x) >= maxSpeed)
        {
            // ... set the player's velocity to the maxSpeed in the x axis.
            //Mathf.Sign: retorna 1 se o valor for 0 ou positivo, e retorna -1 se negativo
            rgd2D.velocity = new Vector2(Mathf.Sign(rgd2D.velocity.x) * (maxSpeed), rgd2D.velocity.y);
        }
        // If the input is moving the player right and the player is facing left...
        if ((h > 0 && !facingRight) || (h < 0 && facingRight))
            // ... flip the player.
            Flip();
    }

    void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;
        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}