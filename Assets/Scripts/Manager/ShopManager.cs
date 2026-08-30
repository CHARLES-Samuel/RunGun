using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{   
    [SerializeField] private WeaponMenuManager weaponMenuManager;
    [SerializeField] private WeaponsSO[] allWeaponsCatalogue;

    public bool forBuy;
    private TextMeshProUGUI buttonText;

    void Awake()
    {
        buttonText = GetComponentInChildren<TextMeshProUGUI>();
    }

    void Start()
    {
        weaponMenuManager.OnBtnChanged += RefreshDisplay; 
    }

    void OnDestroy()
    {
        weaponMenuManager.OnBtnChanged -= RefreshDisplay;
    }

    private int GetWeaponPrice(string weaponID)
    {
        foreach (WeaponsSO weaponsSO in allWeaponsCatalogue)
        {
            if (weaponsSO.ID == weaponID) return weaponsSO.price;
        }
        return 0;
    }

    private void RefreshDisplay(Button clickedButton)
    {   
        if (forBuy)
        {
            buttonText.text = GetWeaponPrice(clickedButton.name).ToString();
        }
        else
        {
            buttonText.text = "Equip";
        }
    }

    public void OnButtonClick()
    {       
        if (forBuy)
        {
            TryToBuy(weaponMenuManager.currentButton.name);
        }
        else
        {
            string weaponID = weaponMenuManager.currentButton.name;
            SaveManager.instance.playerData.equipedWeaponID = weaponID;
            SaveManager.instance.SaveToJson();
        }
    }

    private void TryToBuy(string weaponID)
    {   
        int priceOfWeapon = GetWeaponPrice(weaponID);

        if (SaveManager.instance.playerData.coins >= priceOfWeapon)
        {
            SaveManager.instance.AddCoinsToBank(-priceOfWeapon); 
            SaveManager.instance.playerData.UnlockWeapon(weaponID);
            SaveManager.instance.SaveToJson();
            
            forBuy = false;
            RefreshDisplay(weaponMenuManager.currentButton);
        }
    }
}