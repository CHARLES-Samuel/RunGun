using TMPro;
using UnityEngine;

public class CurrentMunition : MonoBehaviour
{   
    [SerializeField] private Weapon playerWeapon;

    private TextMeshProUGUI nbOfMunitionUi;

    void Awake()
    {
        nbOfMunitionUi = gameObject.GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        RefreshDisplay();

        // on "s'abonne" a l'event de weapon, on va detecter a chaque fois qu'il nous envoie un message
        // on lance le refresh quand on le receptionne
        playerWeapon.OnAmmoChanged += RefreshDisplay; 
    }

    void OnDestroy()
    {
        // Bonne pratique : on se désabonne si l'UI est détruite pour éviter les bugs mémoire
        if (playerWeapon != null)
        {
            playerWeapon.OnAmmoChanged -= RefreshDisplay;
        }
    }

    private void RefreshDisplay()
    {
        nbOfMunitionUi.text = playerWeapon.currentMunition.ToString(); 
    }
}
