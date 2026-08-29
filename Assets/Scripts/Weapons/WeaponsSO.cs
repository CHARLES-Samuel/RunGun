using UnityEngine;

[CreateAssetMenu(fileName = "WeaponsSO", menuName = "Scriptable Objects/WeaponsSO")]
public class WeaponsSO : ScriptableObject
{   
    public string ID;
    public string weaponName;
    public float weaponRange;
    public int weaponDamage;
    public int chargerSize;
    public float rateOfFire;
    public int bulletCount;
    public float spreadAngle;
}
