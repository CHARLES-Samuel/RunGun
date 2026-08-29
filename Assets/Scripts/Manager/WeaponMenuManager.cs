using UnityEngine;
using UnityEngine.UI;

public class WeaponMenuManager : MonoBehaviour
{
    private Button[] buttonsList;

    void Awake()
    {
        buttonsList = gameObject.GetComponentsInChildren<Button>();
    }

    void Start()
    {
        string savedWeaponId = SaveManager.instance.playerData.EquipedWeaponID;

        foreach (Button btn in buttonsList)
        {
            if (btn.gameObject.name == savedWeaponId)
            {
                btn.image.color = Color.lightBlue;
            }
            else
            {
                btn.image.color = Color.white;
            }
        }
    }

    public void OnButtonClick(Button clickedButton)
    {
        foreach (Button button in buttonsList)
        {
            button.image.color = Color.white;
        }

        clickedButton.image.color = Color.lightBlue;

        string weaponID = clickedButton.name;
        SaveManager.instance.playerData.EquipedWeaponID = weaponID;
        SaveManager.instance.SaveToJson();
    }
}
