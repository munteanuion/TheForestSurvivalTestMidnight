using UnityEngine;

[CreateAssetMenu(fileName = "WeaponStat", menuName = "Weapon")]
public class WeaponStat : ScriptableObject
{
    public string weaponName;
    public float _damage = 5;
    public bool _twoHandWeapon;
    public GameObject _inventoryIcon;
    public GameObject _thisWeaponPrefab;

    public float GetDamage()
    {
        return _damage;
    }

    public GameObject GetInventoryIconPrefab()
    {
        return _inventoryIcon;
    }

    public bool HasTwoHandWeapon()
    {
        return _twoHandWeapon;
    }

    public GameObject GetPrefab()
    {
        return _thisWeaponPrefab;
    }
}