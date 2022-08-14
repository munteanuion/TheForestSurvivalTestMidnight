using UnityEngine;

public class ParameterEnemyStats : MonoBehaviour
{
    [SerializeField] private EnemyStats _enemyStats;
    [SerializeField] private Animator _enemyAnimator;

    private const string ATTACK_NAME_ANIMATOR = "Attack1";

    public EnemyStats GetEnemyStats()
    {
        return this._enemyStats;
    }

    public bool IsPlayAttackAnimation()
    {
        return this._enemyAnimator.GetCurrentAnimatorStateInfo(0).IsName(ATTACK_NAME_ANIMATOR);
    }
}
