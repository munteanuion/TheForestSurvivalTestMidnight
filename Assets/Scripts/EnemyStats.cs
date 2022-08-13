using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] private float _damage = 10;
    [SerializeField] private float _speed = 10;

    public float GetEnemyDamage()
    {
        return this._damage;
    }

    public float GetEnemySpeed()
    {
        return this._speed;
    }
}
