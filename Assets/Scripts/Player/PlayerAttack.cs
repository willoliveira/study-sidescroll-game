using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{
    public Rigidbody2D bullet;

    private PlayerMovement pMovement;
    private LayerMask shootableMask;

    // Use this for initialization
    void Start()
    {
        pMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        shootableMask = LayerMask.GetMask("Enemies");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && pMovement.canMove)
            Shoot();
    }

    private void Shoot()
    {
        Rigidbody2D bulletInstance;
        RaycastHit2D shootRay2D;
        RaycastHit shootRay;

        if (pMovement.facingRight)
        {
            bulletInstance = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
            bulletInstance.velocity = new Vector2(10f, 0);
        }
        else
        {
            bulletInstance = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
            bulletInstance.velocity = new Vector2(-10f, 0);
        }
    }

    void FixedUpdate()
    {

    }
}