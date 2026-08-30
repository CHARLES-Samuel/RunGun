using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private Transform enemyHealthBar;
    [SerializeField] private int rewardValue;

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
        PlayerInventory.instance.ModifyCoins(rewardValue);
        Destroy(gameObject);
    }

    private void UpdateEnemyHealthBar()
    {
        float percentageHealth = (float)currenHealth / maxHealth;
        percentageHealth = Mathf.Clamp(percentageHealth, 0f, 1f); // si plus petit, force la valeur a 0, si plus grand que 1 force a 1
        enemyHealthBar.localScale = new Vector3(percentageHealth,enemyHealthBar.localScale.y,1f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealthScript = collision.gameObject.GetComponent<PlayerHealth>();
            playerHealthScript.Die();
        }
    }
}
