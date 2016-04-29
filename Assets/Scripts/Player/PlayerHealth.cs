using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Movement;

public class PlayerHealth : DefaultHealth
{
    private BaseMovement bMovement;
    private PlayerMovement pMovement;
    private SpriteRenderer sRenderer;

    private bool isInvencible = false;
    [SerializeField]
    private float timeForInvencible = 1f;
    private float counter = 0f;

    protected override void Awake()
    {
        rgd2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
        bMovement = GetComponent<BaseMovement>();
        pMovement = GetComponent<PlayerMovement>();
        sRenderer = GetComponent<SpriteRenderer>();
    }
    
    void FixedUpdate()
    {
        counter += Time.deltaTime;
        if (counter < timeForInvencible)
        {
            if (sRenderer.color.a == 1f)
            {
                sRenderer.color = new Color(sRenderer.color.r, sRenderer.color.g, sRenderer.color.b, 0f);
            }
            else
            {
                sRenderer.color = new Color(sRenderer.color.r, sRenderer.color.g, sRenderer.color.b, 1f);
            }
        }
        else
            isInvencible = false;




        if (isDamage && !isInvencible)
        {
            isInvencible = true;
            //Desabilita o dano
            isDamage = false;
            //Aplica uma forçao para traz
            rgd2D.AddForce(Vector2.up * 200f, ForceMode2D.Force);
            if (bMovement.m_FacingRight)
                rgd2D.AddForce(Vector2.right * -2000f, ForceMode2D.Force);
            else
                rgd2D.AddForce(Vector2.right * 2000f, ForceMode2D.Force);
            pMovement.canMove = false;
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
        pMovement.canMove = true;
    }

    //void OnMouseDown()
    //{
    //    TakeDamage(10);
    //}
}