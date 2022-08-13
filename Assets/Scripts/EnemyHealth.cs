using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _maxHp = 50;

    private Animator _playerAnimator;
    private const string WEAPON_NAME_TAG = "Weapon", DEATH_PARAMETER_ANIMATOR = "Death";
    private int _hp;
    public event Action<float> HealthChanged;

    private void Awake()
    {
        _hp = _maxHp;
        _playerAnimator = GetComponent<Animator>();
    }
    
    private void OnTriggerEnter(Collider collider)
    {
        switch (collider.gameObject.tag)
        {
            case WEAPON_NAME_TAG:
                ChangeHealth(-collider.gameObject.GetComponent<WeaponStats>().GetDamage());
                collider.gameObject.GetComponent<MeshCollider>().enabled = false;
                    
                break;
            default:
                break;
        }
    }

    public void ChangeHealth(float value)
    {
        _hp += (int)value;
        if (_hp > _maxHp)
            _hp = _maxHp;

        if (_hp <= 0)
            Death();
        else
            HealthChanged?.Invoke((float) _hp / _maxHp);
    }

    private void Death()
    {
        HealthChanged?.Invoke(0);
        _playerAnimator.SetTrigger(DEATH_PARAMETER_ANIMATOR);
        this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
        this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        transform.gameObject.GetComponent<NavMeshAgent>().speed = 0;
        Invoke("DestroyEnemy", 2f);
    }

    public int GetHealth()
    {
        return _hp;
    }

    public void DestroyEnemy()
    {
        Destroy(this.gameObject);
    }
}
