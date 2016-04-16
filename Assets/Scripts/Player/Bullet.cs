using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{

    public int DamageValue = 10;

    private EnemyHealth eHealth;
    private Animator anim;
    private Rigidbody2D rgd2D;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        rgd2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void OnTriggerEnter2D(Collider2D coll) {
        //Debug.Log(coll.gameObject.tag);
        
        if (coll.gameObject.tag == "Enemy") {
            //Da o dano no inimigo
            eHealth = coll.gameObject.GetComponent<EnemyHealth>();
            eHealth.TakeDamage(DamageValue);
            //Tira a velocidade da bala
            rgd2D.velocity = new Vector2(0, 0);
            //Dispara a animação de hit dela
            anim.SetTrigger("Hit");
        }
    }

    void onAnimationEnd()
    {
        //No fim da animação da bala, destroi ela
        Destroy(gameObject);
    }
}
