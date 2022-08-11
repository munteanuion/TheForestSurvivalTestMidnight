using UnityEngine;
using UnityEngine.AI;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] private float _hp = 10;
    [SerializeField] private float _damage = 10;
    [SerializeField] private float _speed = 10;
    [SerializeField] private GameObject _prefabGenerateAfterDeath;

    private const string DEATH_NAME_ANIMATOR = "Death", WEAPON_NAME_TAG = "Weapon";


    private void OnTriggerEnter(Collider collider)
    {
        switch (collider.gameObject.tag)
        {
            case WEAPON_NAME_TAG:
                TakeDamage(collider.gameObject.GetComponent<WeaponStats>().GetDamage());
                Destroy(collider.gameObject);
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
        if(_hp <= 0 && !transform.GetComponent<Animator>().GetBool(DEATH_NAME_ANIMATOR))
        {
            //PrefabGenerateAfterDeath();
            transform.GetComponent<Animator>().SetBool(DEATH_NAME_ANIMATOR, true);
            transform.GetComponent<CapsuleCollider>().enabled = false;
            transform.gameObject.GetComponent<NavMeshAgent>().speed = 0;
            Invoke("DestroyEnemy", 1.8f);
        }
    }

    public void PrefabGenerateAfterDeath()
    {
        Instantiate(_prefabGenerateAfterDeath, transform.position, Quaternion.identity);
    }

    public void DestroyEnemy()
    {
        Destroy(this.gameObject);
    }
}
