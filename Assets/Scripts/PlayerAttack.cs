using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject _targetHand;

    private Animator _animator;
    private const string ATTACK1_NAME_ANIMATOR = "AttackTwoHand", ATTACK1_PARAMETER_ANIMATOR = "AttackTwoHand";
    private const string BLOCK_NAME_ANIMATOR = "Block", BLOCK_PARAMETER_ANIMATOR = "Block";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (
            Input.GetKeyDown(KeyCode.Mouse0) && 
            !_animator.GetCurrentAnimatorStateInfo(0).IsName(ATTACK1_NAME_ANIMATOR) &&
            _targetHand.transform.childCount != 0
            )
        {
            _animator.SetTrigger(ATTACK1_PARAMETER_ANIMATOR);
            _targetHand.gameObject.GetComponentInChildren<MeshCollider>().enabled = true;
            Invoke("DisableColliderWeapon", 2);
        }
        else if (
            Input.GetKeyDown(KeyCode.Mouse1) && 
            !_animator.GetCurrentAnimatorStateInfo(0).IsName(BLOCK_NAME_ANIMATOR)
            )
        {
            _animator.SetBool(BLOCK_PARAMETER_ANIMATOR, true);
        }
        else if (
            _animator.GetBool(BLOCK_PARAMETER_ANIMATOR) && 
            ( Input.GetKeyUp(KeyCode.Mouse1) || !Input.GetKey(KeyCode.Mouse1) )
            )
        {
            _animator.SetBool(BLOCK_PARAMETER_ANIMATOR, false);
        }  
    }

    private void DisableColliderWeapon()
    {
        _targetHand.gameObject.GetComponentInChildren<MeshCollider>().enabled = false;
    }
}
