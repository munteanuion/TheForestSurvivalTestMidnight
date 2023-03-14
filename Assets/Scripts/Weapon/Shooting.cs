using BigRookGames.Weapons;
using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private WeaponStats _weaponStats; 
    [SerializeField] private PickUpObject _pickUpObject; 
    [SerializeField] private float _range = 20f; 
    [SerializeField] private GunfireController _gunfireController;
    [SerializeField] private string _enemyTag = "Enemy"; 

    private AudioSource _audioSource; 
    private float _nextFireTime = 0f;
    private float _fireRate = 0.1f;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
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

        /*_audioSource.Play(); 
        _muzzleFlash.Play();
        _lineRenderer.enabled = true; 
        _lineRenderer.SetPosition(0, _gunEnd.position); 

        RaycastHit hit; 
        if (Physics.Raycast(_gunEnd.position, _gunEnd.forward, out hit, _range)) 
        {
            _lineRenderer.SetPosition(1, hit.point); 

            if (hit.transform.CompareTag(_enemyTag)) 
            {
                hit.transform.GetComponent<EnemyHealth>().ChangeHealth(_weaponStats.GetDamage()); 
            }

            if (hit.rigidbody != null) 
            {
                hit.rigidbody.AddForce(-hit.normal * _impactForce); 
            }
        }
        else 
        {
            _lineRenderer.SetPosition(1, _gunEnd.position + _gunEnd.forward * _range); 
        }

        StartCoroutine(Hide_lineRenderer()); */
    }

    private IEnumerator Hide_lineRenderer()
    {
        yield return new WaitForSeconds(0.05f); 
        //_lineRenderer.enabled = false; 
    }
}


