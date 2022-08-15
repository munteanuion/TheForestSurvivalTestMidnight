using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject _targetHand;

    private Animator _animator;
    private const string ATTACK1_NAME_ANIMATOR = "AttackTwoHand", ATTACK1_PARAMETER_ANIMATOR = "AttackTwoHand";
    private const string ATTACK2_NAME_ANIMATOR = "AttackOneHand", ATTACK2_PARAMETER_ANIMATOR = "AttackOneHand";
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
            if (_targetHand.gameObject.GetComponentInChildren<BoxCollider>().enabled == false && 
                !_animator.GetCurrentAnimatorStateInfo(0).IsName(ATTACK1_NAME_ANIMATOR) && 
                !_animator.GetCurrentAnimatorStateInfo(0).IsName(ATTACK2_NAME_ANIMATOR))
            {
                _targetHand.gameObject.GetComponentInChildren<BoxCollider>().enabled = true;
                Invoke("DisableColliderWeapon", 2);
            }

            if (_targetHand.gameObject.GetComponentInChildren<WeaponStats>().HasTwoHandWeapon())
            {
                _animator.SetTrigger(ATTACK1_PARAMETER_ANIMATOR);
            }else{
                _animator.SetTrigger(ATTACK2_PARAMETER_ANIMATOR);
            }
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
        for (int i = 0; i < _targetHand.transform.childCount; i++)
        {
            if (_targetHand.transform.GetChild(i).gameObject.activeSelf)
            {
                _targetHand.transform.GetChild(i).gameObject.GetComponentInChildren<BoxCollider>().enabled = false;
                break;
            }
        }

    }
}
