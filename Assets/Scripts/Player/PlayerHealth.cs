using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int currenHealth;
    [SerializeField] private HealthBar healthBar;

    void Start()
    {
        currenHealth = maxHealth;
        healthBar.setMaxHealthUI(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currenHealth -= damage;
        
        if (currenHealth - damage <= 0)
        {   
            Debug.Log("Mort");
        }

        healthBar.setHealthUI(currenHealth);
    }
}
