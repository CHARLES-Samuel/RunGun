using UnityEngine;

/**
    Gere le tir du personnage
*/
public class PlayerShoot : MonoBehaviour
{   
    [SerializeField] private Weapon currentWeapon;

    private Camera mainCam;

    void Start()
    {
        mainCam = Camera.main;
    }

    void Update()
    {   
        if (currentWeapon == null)
        {
            return;
        }

        Vector3 mousPosition = mainCam.ScreenToWorldPoint(Input.mousePosition);

        currentWeapon.Aiming(mousPosition);

        if (Input.GetMouseButton(0))
        {   
            currentWeapon.TryShoot();
        }
    }
}
