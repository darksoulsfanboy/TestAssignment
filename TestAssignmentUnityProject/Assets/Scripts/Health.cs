using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private ParticleSystem deathParticle;


    public UnityEvent OnDeath;
    
    private float currentHealth;
    private bool isDead = false;
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth, maxHealth);
    }
    
    
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth, maxHealth);
        if (currentHealth <= 0 && !isDead)
        {
            isDead = true;
            OnDeath?.Invoke();        
        }
    }

    public void Death()
    {
        Score.AddScore();
        Instantiate(deathParticle, transform.position, deathParticle.transform.rotation);
        

        Destroy(gameObject);
    }
    
    
}
