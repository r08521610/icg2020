using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
  [SerializeField] int health = 100;
  [SerializeField] GameObject deathEffect;
  [SerializeField] Animator animator;

  private bool m_wasHurting = false;

  public void TakeDamage(int damage)
  {
    if (!m_wasHurting) health -= damage;

    if (health <= 0) Die();
    else if (!m_wasHurting) animator.SetBool("IsHurt", true);
    
    m_wasHurting = true;
  }

  public void OnTakeDamageEnd ()
  {
    m_wasHurting = false;
    animator.SetBool("IsHurt", false);
    Debug.Log ("Hurt end");
  }

  void Die()
  {
    Instantiate(deathEffect, transform.position, Quaternion.identity);
    Destroy(gameObject);
  }
}
