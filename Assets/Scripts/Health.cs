using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    [SerializeField] public float currentHealth;
    public Action<DamageDealer> onTakeDamage;
    public Action onGainHealth;
    public bool invincible = false;
    [SerializeField]private float invincibleTimer = 1f;
    
    private void Start()
    {
        currentHealth = maxHealth;
    }
    
    public void GainHealth(float healAmount)
    {
        currentHealth += healAmount;
        //if current health is above max health it returns max health if it's under 0 it returns 0
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        onGainHealth?.Invoke();
    } 
    
    public void TakeDamage(float damageValue,DamageDealer damageDealer,GameObject damaged)
    {
        if (invincible)
            return;
        currentHealth -= damageValue;
        Debug.Log($"{gameObject.name} took damage");
        onTakeDamage?.Invoke(damageDealer);
    
        if (currentHealth <= 0)
            HandleDeath();
    }

    private void HandleDeath()
    {
        Debug.Log($"{name} died");
    }
    
}
