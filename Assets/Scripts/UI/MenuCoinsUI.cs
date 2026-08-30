using TMPro;
using UnityEngine;

public class MenuCoinsUI : MonoBehaviour
{       
    private TextMeshProUGUI nbOfCoinsUI;

    void Awake()
    {
        nbOfCoinsUI = gameObject.GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        if (SaveManager.instance != null)
        {
            RefreshDisplay();
            SaveManager.instance.OnBankCoinsChanged += RefreshDisplay; 
        }
    }

    void OnDestroy()
    {
        if (SaveManager.instance != null)
        {
            SaveManager.instance.OnBankCoinsChanged -= RefreshDisplay;
        }
    }

    private void RefreshDisplay()
    {
        nbOfCoinsUI.text = SaveManager.instance.playerData.coins.ToString(); 
    }
}