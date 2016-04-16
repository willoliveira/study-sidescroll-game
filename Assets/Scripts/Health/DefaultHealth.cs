using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public abstract class DefaultHealth : MonoBehaviour
{
    public float TotalHealth = 300;
    public float currentHealth;
    //UI
    public Slider HealthSlider;
    public Text HPInfo;
    public Text HPInfoTotal;
    //
    protected Animator anim;
    protected Rigidbody2D rgd2D;
    protected bool isDamage = false;

    protected virtual void Awake()
    {
        //Pega a referencia do Rigidbody2D
        rgd2D = GetComponent<Rigidbody2D>();
        //Referencia da animaçao
        anim = GetComponent<Animator>();
    }

    // Use this for initialization protected virtual 
    protected virtual void Start()
    {
        //Seta o health atual
        currentHealth = TotalHealth;
        //Atualiza UI
        HealthSlider.value = 1; //Slider vai de 0 a 1
        HPInfo.text = currentHealth.ToString();
        HPInfoTotal.text = TotalHealth.ToString();
    }    

    protected void UpdateLifeUI()
    {
        //Atualiza o slider
        HealthSlider.value = (currentHealth / TotalHealth);
        //Atribui o life no status
        HPInfo.text = currentHealth.ToString();
    }

    virtual public void TakeDamage(int damage)
    {
        isDamage = true;
        if (currentHealth - damage <= 0)
        {
            Die();
        }
        else
        {
            //Da dano no life do jogador
            currentHealth -= damage;
            //Animaçao de dano
            anim.SetTrigger("Damage");
        }
        //Atualiza o HUD
        UpdateLifeUI();
    }

    protected abstract void Die();
}
