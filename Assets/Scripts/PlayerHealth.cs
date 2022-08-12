using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _maxHp = 100;
    [SerializeField] private Animator _playerAnimator;

    private const string HANDSPIDER_NAME_TAG = "HandSpider", DEATH_NAME_ANIMATOR = "Death";
    private int _hp;
    public event Action<float> HealthChanged;

    private void Awake()
    {
        _hp = _maxHp;
    }
    
    private void OnTriggerEnter(Collider collider)
    {
        switch (collider.gameObject.tag)
        {
            case HANDSPIDER_NAME_TAG:
                if(collider.gameObject.GetComponent<ParameterEnemyStats>().IsPlayAttackAnimation())
                    ChangeHealth(-collider.gameObject.GetComponent<ParameterEnemyStats>().GetEnemyStats().GetEnemyDamage());
                break;
            default:
                break;
        }
    }

    private void ChangeHealth(float value)
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
        _playerAnimator.SetTrigger(DEATH_NAME_ANIMATOR);
        this.gameObject.GetComponent<CapsuleCollider>().isTrigger = true;
        this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    public int GetHealth()
    {
        return _hp;
    }
}
