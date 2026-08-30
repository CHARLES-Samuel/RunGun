using TMPro;
using UnityEngine;

public class CoinsUI : MonoBehaviour
{       
    private TextMeshProUGUI nbOfCoinsUI;

    void Awake()
    {
        nbOfCoinsUI = gameObject.GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        RefreshDisplay();

        // on "s'abonne" a l'event de weapon, on va detecter a chaque fois qu'il nous envoie un message
        // on lance le refresh quand on le receptionne
        PlayerInventory.instance.OnCoinsChanged += RefreshDisplay; 
    }

    void OnDestroy()
    {
        // on se désabonne si l'UI est détruite pour éviter les bugs mémoire
        PlayerInventory.instance.OnCoinsChanged -= RefreshDisplay;
    }

    private void RefreshDisplay()
    {
        nbOfCoinsUI.text = PlayerInventory.instance.currentCoins.ToString(); 
    }
}
