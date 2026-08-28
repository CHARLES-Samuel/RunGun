using UnityEngine;

/**
    Gere le fonctionnement d'une arme
*/
public class Weapon : MonoBehaviour
{

    [SerializeField] private BulletScript bulletPrefab;
    [SerializeField] private Transform bulletTransform;

    [SerializeField] private WeaponsSO typeOfWeapon;

    private float timer;

    void Update()
    {
        if (timer > 0f)
        {
            timer -= Time.deltaTime;
        }

    }

    // Vise une direction passee en parametre
    public void Aiming(Vector3 aimingObject)
    {   
        Vector3 rotation = aimingObject - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,rotZ);
    }

    // Test si le tir peut etre effectue
    public bool TryShoot()
    {
        if(timer <= 0f)
        {
            Shoot();
            timer = typeOfWeapon.rateOfFire;
            return true;
        }
        return false;
    }

    // instantie une nouvelle balle
    public void Shoot()
    {   
        BulletScript newBullet = Instantiate(bulletPrefab, bulletTransform.position, bulletTransform.rotation);
        newBullet.Setup(typeOfWeapon.weaponDamage,typeOfWeapon.weaponRange);
    }

}
