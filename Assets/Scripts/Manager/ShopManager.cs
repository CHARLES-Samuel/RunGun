using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{   
    [SerializeField] private WeaponMenuManager weaponMenuManager;
    [SerializeField] private WeaponsSO[] allWeaponsCatalogue;

    public bool forBuy;
    private TextMeshProUGUI buttonText;
    private Button backgroundBuyBtn;

    void Awake()
    {
        buttonText = GetComponentInChildren<TextMeshProUGUI>();
        backgroundBuyBtn = GetComponentInChildren<Button>();
    }

    void OnEnable()
    {
        weaponMenuManager.OnBtnChanged += RefreshDisplay; 
        
        if (weaponMenuManager.currentButton != null)
        {
            RefreshDisplay(weaponMenuManager.currentButton);
        }
    }

    void OnDisable()
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
            backgroundBuyBtn.image.color = Color.white;
        }
        else
        {   
            string currentWeaponID = SaveManager.instance.playerData.equipedWeaponID;
            
            if (weaponMenuManager.currentButton.name == currentWeaponID)
            {
                backgroundBuyBtn.image.color = Color.green;
                buttonText.text = "Equipped";
            }
            else
            {
                backgroundBuyBtn.image.color = Color.white;
                buttonText.text = "Equip";
            }
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
        RefreshDisplay(weaponMenuManager.currentButton);
    }

    private void TryToBuy(string weaponID)
    {   
        int priceOfWeapon = GetWeaponPrice(weaponID);

        if (SaveManager.instance.playerData.coins >= priceOfWeapon)
        {
            SaveManager.instance.AddCoinsToBank(-priceOfWeapon); 
            SaveManager.instance.playerData.UnlockWeapon(weaponID);
            SaveManager.instance.playerData.equipedWeaponID = weaponID;
            SaveManager.instance.SaveToJson();
            
            forBuy = false;
            RefreshDisplay(weaponMenuManager.currentButton);
        }
    }
}