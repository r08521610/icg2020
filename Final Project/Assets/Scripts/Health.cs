using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] GameObject deathEffect;
    
    public void TakeDamage (int damage)
    {
        health -= damage;

        if (health <= 0) Die();
    }

    void Die ()
    {
        Instantiate (deathEffect, transform.position, Quaternion.identity);
        Destroy (gameObject);
    }
}
