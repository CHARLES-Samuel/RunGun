using UnityEngine;
using System.Collections;

/**
    Gere l'aspect "vie" du personnage
*/
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private GameOverManager gameOverManager;

    private PlayerMovement playerMovement;
    private bool isInvicible;
    private float invicibilityFlashDelay = 0.1f;
    private float invicibilityTimeAfterHit = 1.5f;
    [SerializeField] private SpriteRenderer graphics;

    void Awake()
    {
        graphics = gameObject.GetComponent<SpriteRenderer>();
        playerMovement = gameObject.GetComponent<PlayerMovement>();
    }

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealthUI(maxHealth);
    }

    // Enleve de la vie au personnage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        
        if (currentHealth <= 0)
        {   
            Die();
        }

        healthBar.SetHealthUI(currentHealth);
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
        SaveManager.instance.AddCoinsToBank(PlayerInventory.instance.currentCoins);

        // arrete le deplacement en cours
        playerMovement.rb.linearVelocity = Vector3.zero;
        // bloquer les mouvements du perso
        playerMovement.enabled = false;
        // empecher les interactions physique avec les autres elements de la scene
        playerMovement.rb.bodyType = RigidbodyType2D.Kinematic;
        playerMovement.playerCollider.enabled = false;

        gameOverManager.OnPlayerDeath();
    }

    public void Respawn()
    {
        // bloquer les mouvements du perso
        playerMovement.enabled = true;
        // empecher les interactions physique avec les autres elements de la scene
        playerMovement.rb.bodyType = RigidbodyType2D.Dynamic;
        currentHealth = maxHealth;
        healthBar.SetHealthUI(currentHealth);
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
