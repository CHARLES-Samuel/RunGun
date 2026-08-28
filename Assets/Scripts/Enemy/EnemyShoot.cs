using System.Runtime.Serialization.Formatters;
using UnityEngine;

/**
    Gere les tires des ennemis
*/
public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private Weapon currentWeapon;
    [SerializeField] private Transform target;
    [SerializeField] private float detectionRange;

    void Update()
    {   
        if (currentWeapon == null)
        {
            return;
        }

        if (Vector2.Distance(transform.position, target.position) <= detectionRange)
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
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position,detectionRange);
    }
}
