using UnityEngine;
using System.Collections;
using Movement;

public class PlayerAttack : MonoBehaviour
{
    public Rigidbody2D bullet;

    private PlayerMovement pMovement;
    private BaseMovement bMovement;
    private LayerMask shootableMask;

    // Use this for initialization
    void Awake()
    {
        pMovement = GetComponent<PlayerMovement>();
        bMovement = GetComponent<BaseMovement>();
        shootableMask = LayerMask.GetMask("Enemies");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) //&& pMovement.canMove
            Shoot();
    }

    private void Shoot()
    {
        Rigidbody2D bulletInstance;
        RaycastHit2D shootRay2D;
        RaycastHit shootRay;

        if (bMovement.m_FacingRight)
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