using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : DefaultHealth
{

    protected override void Awake()
    {
        rgd2D = GetComponent<Rigidbody2D>();
        //Referencia da animaçao
        anim = GetComponent<Animator>();
    }
    
    void FixedUpdate()
    {
        if (isDamage)
        {
            //Desabilita o dano
            isDamage = false;
            //Aplica uma forçao para traz
            rgd2D.AddForce(Vector2.up * 200f, ForceMode2D.Force);
            if (GetComponent<PlayerMovement>().facingRight)
                rgd2D.AddForce(Vector2.right * -2000f, ForceMode2D.Force);
            else
                rgd2D.AddForce(Vector2.right * 2000f, ForceMode2D.Force);
            //
            GetComponent<PlayerMovement>().canMove = false;
        }
    }

    public void UpgradeLife(float life)
    {
        //Atualiza o life do personagem
        currentHealth += life;
        TotalHealth += life;
        //
        HPInfoTotal.text = TotalHealth.ToString();
    }

    public void RestoreLife(float restore)
    {
        //Debug.Log (restore);
        if (currentHealth + restore > TotalHealth)
            currentHealth = TotalHealth;
        else
            currentHealth += restore;
        //Atualiza o HUD
        UpdateLifeUI();
    }
    

    //only player
    public bool HealthFull()
    {
        return currentHealth == TotalHealth;
    }
    
    protected override void Die()
    {
        //Seta pra zero o life dele
        currentHealth = 0;
        //Animação de morte
        anim.SetTrigger("Damage");
    }

    /// <summary>
    /// Fim da animacao de dano
    /// </summary>
    private void endAnimationDamage()
    {
        GetComponent<PlayerMovement>().canMove = true;
    }

    //void OnMouseDown()
    //{
    //    TakeDamage(10);
    //}
}