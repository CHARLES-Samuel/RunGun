using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletTransform;
    [SerializeField] private float timeBetweenFiring;

    private float timer;

    void Update()
    {
        if (timer > 0f)
        {
            timer -= Time.deltaTime;
        }

    }

    public void Aiming(Vector3 aimingObject)
    {   
        Vector3 rotation = aimingObject - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,rotZ);
    }

    public bool TryShoot()
    {
        if(timer <= 0f)
        {
            Shoot();
            timer = timeBetweenFiring;
            return true;
        }
        return false;
    }

    public void Shoot()
    {
        Instantiate(bulletPrefab, bulletTransform.position, bulletTransform.rotation);
    }

}
