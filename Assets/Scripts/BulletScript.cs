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


}
