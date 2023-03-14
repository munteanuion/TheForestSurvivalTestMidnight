using UnityEngine;

public class WeaponStats : MonoBehaviour
{
    [SerializeField] private float _damage = 5;
    [SerializeField] private bool _twoHandWeapon;
    [SerializeField] private GameObject _inventoryIcon;
    [SerializeField] private GameObject _thisWeaponPrefab;

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
