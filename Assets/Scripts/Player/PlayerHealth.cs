using UnityEngine;
using System.Collections;

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

    public void TakeDamage(int damage)
    {
        currenHealth -= damage;
        
        if (currenHealth <= 0)
        {   
            Debug.Log("Mort");
        }

        healthBar.setHealthUI(currenHealth);
    }

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

    public IEnumerator HandleInvicibilityDelay()
    {
        yield return new WaitForSeconds(invicibilityTimeAfterHit);
        isInvicible = false;
    }
}
