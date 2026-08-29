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

    public void OnCollisionEnter2D(Collision2D collision)
    {   
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealthScript = collision.gameObject.GetComponent<EnemyHealth>();
            enemyHealthScript.TakeDamage(bulletDamage);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {   
            PlayerHealth playerHealthScript = collision.gameObject.GetComponent<PlayerHealth>();
            playerHealthScript.TakeDamage(bulletDamage);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Ground"))
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
