using UnityEngine;
using System.Collections;

public class EnemyMovement : DefaultMovement
{
    void Start()
    {
        facingRight = false;
    }

    protected override float getAxis()
    {
        return facingRight ? 1f : -1f;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Wall")
        {
            //Inverte a direção
            Flip();
        }
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
