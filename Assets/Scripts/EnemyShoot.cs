using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private Weapon currentWeapon;
    [SerializeField] private Transform target;

    void Update()
    {   
        if (currentWeapon == null)
        {
            return;
        }

        currentWeapon.Aiming(target.position);

        currentWeapon.TryShoot();
    }
}
