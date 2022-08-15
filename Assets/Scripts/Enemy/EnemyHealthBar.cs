using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthBarFilling;
    [SerializeField] private EnemyHealth _enemyHealth;
    [SerializeField] private Transform _targetToLook;

    private void Awake()
    {
        _enemyHealth.HealthChanged += OnHealthChanged;
    }

    private void OnDestroy()
    {
        _enemyHealth.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(float valueAsProcentage)
    {
        _healthBarFilling.fillAmount = valueAsProcentage;
        if (valueAsProcentage == 0)
            this.gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        transform.LookAt(_targetToLook.position);
    }
}
