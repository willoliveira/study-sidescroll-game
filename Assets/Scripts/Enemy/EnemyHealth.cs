using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyHealth : DefaultHealth
{

    public Text EnemyName;
    private BoxCollider2D[] bCollider2D;
    protected override void Awake()
    {
        base.Awake();
        //Enemy
        bCollider2D = GetComponents<BoxCollider2D>();
    }

    void FixedUpdate()
    {
        if (isDamage) {
            //Colocar aquela piscada no inimigo
            Debug.Log("Colocar aquela piscada no inimigo!");
        }
    }

    public bool HealthFull()
    {
        return currentHealth == TotalHealth;
    }

    public override void TakeDamage(int damage)
    {
        //Chama o metodo da classe pai
        base.TakeDamage(damage);
        //Enemy only
        EnemyName.text = gameObject.name;
    }

    protected override void Die()
    {
        rgd2D.isKinematic = true;
        //Desabilta o box collider do inimigo
        foreach (BoxCollider2D b in bCollider2D)
            b.enabled = false;
        //Seta a vida para zero
        currentHealth = 0;
        //anim de morte
        anim.SetTrigger("Die");

    }

    void onAnimationEnd()
    {
        //No fim da animação da bala, destroi ela
        Destroy(gameObject);
    }

}

