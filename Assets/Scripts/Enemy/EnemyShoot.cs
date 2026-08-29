using System.Runtime.Serialization.Formatters;
using Unity.VisualScripting;
using UnityEngine;

/**
    Gere les tires des ennemis
*/
public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private Weapon currentWeapon;
    
    private Transform target;

    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Start()
    {
        currentWeapon.InitializeWeapon();
    }

    void Update()
    {   
        if (currentWeapon == null)
        {
            return;
        }

        if (Vector2.Distance(transform.position, target.position) <= currentWeapon.typeOfWeapon.weaponRange)
        {
            EnemyShooting();
        }        
    }

    // Active le tire ennemi
    private void EnemyShooting()
    {
        currentWeapon.Aiming(target.position);
        currentWeapon.TryShoot();
    }

    void OnDrawGizmosSelected()
    {
        if (currentWeapon != null && currentWeapon.typeOfWeapon != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, currentWeapon.typeOfWeapon.weaponRange);
        }
    }
}
