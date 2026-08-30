using UnityEngine;

/**
    Gere le tir du personnage
*/
public class PlayerShoot : MonoBehaviour
{   
    [SerializeField] private Weapon currentWeapon;

    [SerializeField] private WeaponsSO[] allWeaponsCatalogue;

    private Camera mainCam;

    void Start()
    {
        mainCam = Camera.main; 
        string saveWeaponId = SaveManager.instance.playerData.equipedWeaponID;

        foreach (WeaponsSO weaponsSO in allWeaponsCatalogue)
        {
            if (weaponsSO.ID == saveWeaponId)
            {
                currentWeapon.typeOfWeapon = weaponsSO;
                currentWeapon.InitializeWeapon();
                break;
            }
        }
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
