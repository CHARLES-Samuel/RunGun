using UnityEngine;
using System.Collections;

/**
    Gere l'aspect "vie" du personnage
*/
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int currenHealth;
    [SerializeField] private HealthBar healthBar;

    private bool isInvicible;
    private float invicibilityFlashDelay = 0.1f;
    private float invicibilityTimeAfterHit = 1.5f;
    [SerializeField] private SpriteRenderer graphics;

    void Awake()
    {
        graphics = gameObject.GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        currenHealth = maxHealth;
        healthBar.setMaxHealthUI(maxHealth);
    }

    // Enleve de la vie au personnage
    public void TakeDamage(int damage)
    {
        currenHealth -= damage;
        
        if (currenHealth <= 0)
        {   
            Die();
        }

        healthBar.setHealthUI(currenHealth);
    }

    // Enleve de la vie au personnage lorsque cela vient d'un spike
    public void TakeSpikeDamage(int damage)
    {
        if (!isInvicible)
        {
            TakeDamage(damage);
            isInvicible = true;

            StartCoroutine(InvicibilityFlash());
            StartCoroutine(HandleInvicibilityDelay());
        }
    }

    // Mort du personnage
    public void Die()
    {   
        GameManager.instance.Respawn();
    }

    // Fait "clignoter" le personnage pour voir qu'il est invincible
    public IEnumerator InvicibilityFlash()
    {
        while (isInvicible)
        {
            graphics.color = new Color(1f,1f,1f,0f);
            yield return new WaitForSeconds(invicibilityFlashDelay);
            graphics.color = new Color(1f,1f,1f,1f);
            yield return new WaitForSeconds(invicibilityFlashDelay);
        }
    }

    // enleve l'invincibilite apres le temps donne
    public IEnumerator HandleInvicibilityDelay()
    {
        yield return new WaitForSeconds(invicibilityTimeAfterHit);
        isInvicible = false;
    }
}
