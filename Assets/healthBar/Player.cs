using System;
using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _currentHealth;
    public float damage;
    public GameObject healthbarImage;
    [SerializeField] private float _maxHealth;
    [SerializeField] private HealthUI _healthbar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _currentHealth = _maxHealth;
        _healthbar.UpdateHealthBar(_maxHealth, _currentHealth);
    }

    // Update is called once per frame
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            _currentHealth -= damage;

            if (_currentHealth <= 0)
            {
                Destroy(gameObject);
                healthbarImage.SetActive(false);
            }
            else
            {
                _healthbar.UpdateHealthBar(_maxHealth, _currentHealth);
            }
        }
    }
}
