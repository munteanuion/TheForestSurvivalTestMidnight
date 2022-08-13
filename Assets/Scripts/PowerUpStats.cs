using UnityEngine;

public class PowerUpStats : MonoBehaviour
{
    [SerializeField] private int _cleamHealth = 50;

    public int GetHealthInfo()
    {
        return _cleamHealth;
    }

    public void DestoyPowerUp()
    {
        Destroy(transform.gameObject);
    }
}
