using UnityEngine;

/**
    Gere le comportement des balles
*/
public class BulletScript : MonoBehaviour
{   
    [SerializeField] private float bulletSpeed;
    [SerializeField] private Rigidbody2D bulletRb;

    private int bulletDamage;
    private float bulletRange;
    private Vector3 startPosition;

    void Start()
    {
        bulletRb.linearVelocity = transform.right * bulletSpeed;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealthScript = collision.GetComponent<EnemyHealth>();
            enemyHealthScript.TakeDamage(bulletDamage);
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Player"))
        {   
            PlayerHealth playerHealthScript = collision.GetComponent<PlayerHealth>();
            playerHealthScript.TakeDamage(bulletDamage);
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if(Vector3.Distance(startPosition, transform.position) >= bulletRange)
        {
            Destroy(gameObject);
        }
    }

    public void Setup(int newDamage, float newRange)
    {
        bulletDamage = newDamage;
        bulletRange = newRange;

        startPosition = transform.position;
    }
}
