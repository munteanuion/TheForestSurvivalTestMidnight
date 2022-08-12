using UnityEngine;
using UnityEngine.AI;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] private float _hp = 10;
    [SerializeField] private float _damage = 10;
    [SerializeField] private float _speed = 10;
    [SerializeField] private Animator _animator;

    private const string DEATH_PARAMETER_ANIMATOR = "Death", WEAPON_NAME_TAG = "Weapon";
    
    private void OnTriggerEnter(Collider collider)
    {
        switch (collider.gameObject.tag)
        {
            case WEAPON_NAME_TAG:
                if (collider.gameObject.GetComponent<Rigidbody>().isKinematic)
                {
                    TakeDamage(collider.gameObject.GetComponent<WeaponStats>().GetDamage());
                    collider.gameObject.GetComponent<MeshCollider>().enabled = false;
                }
                break;
            default:
                break;
        }
    }

    public float GetEnemyDamage()
    {
        return this._damage;
    }

    public float GetEnemySpeed()
    {
        return this._speed;
    }

    public void TakeDamage(float takeDamage)
    {
        _hp -= takeDamage;
        CheckEnemyHP();
    }

    public void CheckEnemyHP()
    {
        if(_hp <= 0 && !_animator.GetBool(DEATH_PARAMETER_ANIMATOR))
        {
            _animator.SetTrigger(DEATH_PARAMETER_ANIMATOR);
            transform.GetComponent<CapsuleCollider>().enabled = false;
            transform.GetComponent<Rigidbody>().isKinematic = true;
            transform.gameObject.GetComponent<NavMeshAgent>().speed = 0;
            Invoke("DestroyEnemy", 2f);
        }
    }

    public void DestroyEnemy()
    {
        Destroy(this.gameObject);
    }
}
