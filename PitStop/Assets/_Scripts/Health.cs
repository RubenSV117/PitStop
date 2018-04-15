using System.Collections;
using UnityEngine;

/// <summary>
///
/// Ruben Sanchez
/// 
/// </summary>

public class Health : MonoBehaviour
{
    [SerializeField] private int startingHealth;

    private int currentHealth;

    private void OnEnable()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
            Die();
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}

