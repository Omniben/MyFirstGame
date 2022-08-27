using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public float health;
    [SerializeField] protected float maxHealth;

    public bool isDead;


    private void Start()
    {
        
    }



    public virtual void checkHealth()
    {

        if (health > maxHealth)
        {
            health = maxHealth;
        }
        if (health <= 0)
        {
            health = 0;
            Die();
        }
    }

    public void Die()
    {
        isDead = true;
    }


    private void SetHealthTo(float healthToSetTo)
    {
        health = healthToSetTo;
        checkHealth();
    }

    public virtual void takeDamage(float damage)
    {

        float HealthAfterDamage = health - damage;
        SetHealthTo(HealthAfterDamage);
    }

    public void heal(float healing)
    {
        float HealthAfterHeal = health + healing;
        SetHealthTo(HealthAfterHeal);
    }

    public void initVariables()
    {
        maxHealth = 100f;
        SetHealthTo(maxHealth);
        isDead = false;
    }
}
