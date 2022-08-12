using UnityEngine;
using UnityEngine.AI;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] private float _hp = 10;
    [SerializeField] private float _damage = 10;
    [SerializeField] private float _speed = 10;

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
            transform.GetComponent<Animator>().SetBool(DEATH_NAME_ANIMATOR, true);
            transform.GetComponent<CapsuleCollider>().isTrigger = true;
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
