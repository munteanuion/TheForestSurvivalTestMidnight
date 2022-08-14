using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthBarFilling;
    [SerializeField] private EnemyHealth _enemyHealth;

    private Camera _camera;

    private void Awake()
    {
        _enemyHealth.HealthChanged += OnHealthChanged;
        _camera = Camera.main;
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

    private void LateUpdate()
    {
        transform.LookAt(transform.position);
        transform.Rotate(0, 0, 0);
    }
}
