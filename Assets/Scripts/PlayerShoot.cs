using UnityEngine;

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

        if (Input.GetMouseButtonDown(1))
        {   
            currentWeapon.TryShoot();
        }
    }
}
