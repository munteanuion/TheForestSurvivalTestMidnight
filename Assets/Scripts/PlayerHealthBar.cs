using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthBarFilling;
    [SerializeField] private PlayerHealth _playerHealth;

    private void Awake()
    {
        _playerHealth.HealthChanged += OnHealthChanged;
    }

    private void OnDestroy()
    {
        _playerHealth.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(float valueAsProcentage)
    {
        _healthBarFilling.fillAmount = valueAsProcentage;
        if(valueAsProcentage == 0)
            this.gameObject.SetActive(false);
    }
}
