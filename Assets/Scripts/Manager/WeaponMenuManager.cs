using System;
using UnityEngine;
using UnityEngine.UI;

public class WeaponMenuManager : MonoBehaviour
{   
    public event Action<Button> OnBtnChanged;
    public Button currentButton;

    [SerializeField] private ShopManager buyButton;
    private Button[] buttonsList;

    void Awake()
    {
        buttonsList = gameObject.GetComponentsInChildren<Button>();
    }

    void Start()
    {
        string savedWeaponId = SaveManager.instance.playerData.equipedWeaponID;

        foreach (Button btn in buttonsList)
        {
            if (btn.gameObject.name == savedWeaponId)
            {
                btn.image.color = Color.cyan;
                currentButton = btn;
            }
            else
            {
                btn.image.color = Color.white;
            }
        }

        if (currentButton != null)
        {
            OnButtonClick(currentButton);
        }
    }

    public void OnButtonClick(Button clickedButton)
    {   
        ChangeColorOfWeaponSelected(clickedButton);
        currentButton = clickedButton;
        buyButton.forBuy = !SaveManager.instance.playerData.HasWeapon(clickedButton.gameObject.name);
        OnBtnChanged?.Invoke(clickedButton);
    }

    private void ChangeColorOfWeaponSelected(Button clickedButton)
    {
        foreach (Button button in buttonsList)
        {
            button.image.color = Color.white;
        }

        clickedButton.image.color = Color.cyan;
    }
}