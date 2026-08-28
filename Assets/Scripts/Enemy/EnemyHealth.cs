using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private Transform enemyHealthBar;

    private int currenHealth;

    void Awake()
    {
        currenHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currenHealth -= damage;
        UpdateEnemyHealthBar();

        if (currenHealth <= 0)
        {   
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void UpdateEnemyHealthBar()
    {
        float percentageHealth = (float)currenHealth / maxHealth;
        percentageHealth = Mathf.Clamp(percentageHealth, 0f, 1f); // si plus petit, force la valeur a 0, si plus grand que 1 force a 1
        enemyHealthBar.localScale = new Vector3(percentageHealth,enemyHealthBar.localScale.y,1f);
    }
}
