using UnityEngine;

public class BulletScript : MonoBehaviour
{   
    [SerializeField] private float bulletSpeed;
    [SerializeField] private int bulletDamage;
    [SerializeField] private Rigidbody2D bulletRb;

    void Start()
    {
        bulletRb.linearVelocity = transform.right * bulletSpeed;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
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
}
