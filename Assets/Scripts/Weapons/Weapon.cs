using UnityEngine;
using System.Collections;


/**
    Gere le fonctionnement d'une arme
*/
public class Weapon : MonoBehaviour
{
    public WeaponsSO typeOfWeapon;

    [SerializeField] private BulletScript bulletPrefab;
    [SerializeField] private Transform bulletTransform;
    [SerializeField] private float reloadTime;

    private float timer;
    private int currentMunition;
    private bool haveMunition;

    void Start()
    {
        currentMunition = typeOfWeapon.chargerSize;
        haveMunition = true;
    }

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
        if(timer <= 0f && haveMunition)
        {
            Shoot();
            timer = typeOfWeapon.rateOfFire;
            return true;
        }
        return false;
    }

    // instantie une nouvelle balle
    private void Shoot()
    {   
        BulletScript newBullet = Instantiate(bulletPrefab, bulletTransform.position, bulletTransform.rotation);
        newBullet.Setup(typeOfWeapon.weaponDamage,typeOfWeapon.weaponRange);
        currentMunition--;

        if (currentMunition <= 0)
        {   
            haveMunition = false;
            StartCoroutine(HandleReloadDelay());
        }
    }

    public IEnumerator HandleReloadDelay()
    {
        yield return new WaitForSeconds(reloadTime);
        currentMunition = typeOfWeapon.chargerSize;
        haveMunition = true;
    }
}
