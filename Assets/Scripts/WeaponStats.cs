using UnityEngine;

public class WeaponStats : MonoBehaviour
{
    [SerializeField] private float _damage = 5;
    [SerializeField] private bool _twoHandWeapon;

    public float GetDamage()
    {
        return _damage;
    }

    public bool HasTwoHandWeapon()
    {
        return _twoHandWeapon;
    }
}
