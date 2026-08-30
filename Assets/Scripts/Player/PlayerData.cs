using System.Collections.Generic;

[System.Serializable]
public class PlayerData
{
    public string equipedWeaponID = "smg_01";
    public int coins = 0;
    public List<string> weaponsDeblocked = new List<string> {"smg_01"};

    public void ModifyCoins(int amount)
    {
        coins += amount;
        if (coins < 0) coins = 0;
    }

    public bool HasWeapon(string weaponID)
    {
        return weaponsDeblocked.Contains(weaponID);
    }

    public void UnlockWeapon(string weaponID)
    {
        if (!weaponsDeblocked.Contains(weaponID))
        {
            weaponsDeblocked.Add(weaponID);
        }
    }
}
