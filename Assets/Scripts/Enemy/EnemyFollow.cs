using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyFollow : MonoBehaviour
{
    [SerializeField] private float _viewDistance = 15f;
    [SerializeField] private Transform _targetFollow;
    [SerializeField] private GameObject _colliderHandForAttack;
    [SerializeField] private Animator _animator;

    private const string ATTACK_NAME_ANIMATOR = "Attack1", PARAMETER_NAME_ATTACK = "Attack", PARAMETER_NAME_WALK = "Walk"; 
    private NavMeshAgent _navMeshAgent;
    private Transform _agentTransform;
    private float _speedMove;
    private float _rotationSpeed;
    private float _moveDistanceEnemyPlayer;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.updateRotation = false;
        _rotationSpeed = _navMeshAgent.angularSpeed;
        _moveDistanceEnemyPlayer = _navMeshAgent.stoppingDistance;
        _agentTransform = _navMeshAgent.transform;
    }

    private void FixedUpdate()
    {
        float distancePlayerEnemy = Vector3.Distance(_targetFollow.position, transform.position);

        if (_animator.GetBool(PARAMETER_NAME_ATTACK) == true)
            _animator.SetBool(PARAMETER_NAME_ATTACK, false);

        if (distancePlayerEnemy <= _viewDistance)
        {
            RotateToTarget();

            if (distancePlayerEnemy >= _moveDistanceEnemyPlayer &&
                !_animator.GetCurrentAnimatorStateInfo(0).IsName(ATTACK_NAME_ANIMATOR))
            {
                MoveToTarget();

                if (_animator.GetBool(PARAMETER_NAME_WALK) == false)
                    _animator.SetBool(PARAMETER_NAME_WALK, true);
            }
            else if (distancePlayerEnemy <= _navMeshAgent.stoppingDistance)
            {
                _animator.SetBool(PARAMETER_NAME_ATTACK, true);
                _animator.SetBool(PARAMETER_NAME_WALK, false);

                _navMeshAgent.SetDestination(transform.position);
                _colliderHandForAttack.SetActive(true);
            }
        }
        else if(_animator.GetBool(PARAMETER_NAME_WALK) == true)
        {
            _animator.SetBool(PARAMETER_NAME_WALK, false);
            _navMeshAgent.SetDestination(transform.position);
        }
    }
    
    private void RotateToTarget()
    {
        Vector3 lookVector = _targetFollow.position - _agentTransform.position;
        lookVector.y = 0;
        if (lookVector == Vector3.zero) return;
        _agentTransform.rotation = Quaternion.RotateTowards
            (
                _agentTransform.rotation,
                Quaternion.LookRotation(lookVector, Vector3.up),
                _rotationSpeed * Time.deltaTime
            );
    }

    private void MoveToTarget()
    {
        _navMeshAgent.SetDestination(_targetFollow.position);
    }
}
