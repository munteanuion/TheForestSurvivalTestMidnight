using UnityEngine;

public class ParameterEnemyStats : MonoBehaviour
{
    [SerializeField] private EnemyStats _enemyStats;
    [SerializeField] private Animator _enemyAnimator;

    public EnemyStats GetEnemyStats()
    {
        return this._enemyStats;
    }

    public bool IsPlayAttackAnimation()
    {
        return this._enemyAnimator.GetCurrentAnimatorStateInfo(0).IsName("zombie_attack_right");
    }
}
