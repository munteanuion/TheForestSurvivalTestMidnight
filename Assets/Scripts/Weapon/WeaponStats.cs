using UnityEngine;

public class WeaponStats : MonoBehaviour
{
    [SerializeField] private WeaponStat _WeaponStats;

    public float GetDamage()
    {
        return _WeaponStats.GetDamage();
    }

    public GameObject GetInventoryIconPrefab()
    {
        return _WeaponStats.GetInventoryIconPrefab();
    }

    public bool HasTwoHandWeapon()
    {
        return _WeaponStats.GetPrefab();
    }

    public GameObject GetPrefab()
    {
        return _WeaponStats.GetPrefab();
    }
}
