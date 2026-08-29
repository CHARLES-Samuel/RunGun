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


        if (SaveManager.instance == null) 
    {
        Debug.LogError("ERREUR : Le SaveManager n'est pas dans la scène !");
        return;
    }



        
        string saveWeaponId = SaveManager.instance.playerData.EquipedWeaponID;

        Debug.Log("1. La sauvegarde demande l'arme : [" + saveWeaponId + "]");


        foreach (WeaponsSO weaponsSO in allWeaponsCatalogue)
        {
            Debug.Log("2. Je vérifie le fichier nommé : [" + weaponsSO.ID + "]");
            if (weaponsSO.ID == saveWeaponId)
            {
                currentWeapon.typeOfWeapon = weaponsSO;
                Debug.Log("3. SUCCÈS : Arme trouvée et équipée !");
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
