using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Image _healthbarSprite;

    public void UpdateHealthBar(float maxHealth, float currentHealth)
    {
        if (maxHealth <= 0f) return;

        _healthbarSprite.fillAmount = currentHealth / maxHealth;
    }
    
}
