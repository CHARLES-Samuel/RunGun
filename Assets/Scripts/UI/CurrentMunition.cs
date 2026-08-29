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

    public void Update()
    {
        nbOfMunitionUi.text = playerWeapon.currentMunition.ToString(); 
    }
}
