using BigRookGames.Weapons;
using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform _gunEnd; 
    [SerializeField] private WeaponStats _weaponStats; 
    [SerializeField] private PickUpObject _pickUpObject; 
    [SerializeField] private float _range = 20f; 
    [SerializeField] private GunfireController _gunfireController;
    [SerializeField] private string _enemyTag = "Enemy"; 

    //private AudioSource _audioSource; 
    private float _nextFireTime = 0f;
    private float _fireRate = 0.1f;

    private void Start()
    {
        //_audioSource = GetComponent<AudioSource>();
        _weaponStats = GetComponent<WeaponStats>();
        _pickUpObject = GetComponent<PickUpObject>();
        _gunfireController = GetComponent<GunfireController>();
        _fireRate = _gunfireController.shotDelay;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) 
            && Time.time > _nextFireTime 
            && _pickUpObject.isPicked) 
        {
            _nextFireTime = Time.time + _fireRate; 
            Shoot(); 
        }
    }

    private void Shoot()
    {
        _gunfireController.FireWeapon();
        RaycastHit hit;
        if (Physics.Raycast(_gunEnd.position, _gunEnd.forward, out hit, _range))
        {
            if (hit.transform.CompareTag(_enemyTag))
            {
                hit.transform.GetComponent<EnemyHealth>().ChangeHealth(-_weaponStats.GetDamage());
                //Debug.LogError("Shoot damage");
            }
        }
    }
}


