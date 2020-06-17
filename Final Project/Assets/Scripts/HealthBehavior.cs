using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBehavior : MonoBehaviour
{
  [SerializeField] int health = 100;
  [SerializeField] GameObject deathEffect;
  [SerializeField] Animator animator;

  Player m_Player;
  public Player Player { get { return m_Player; } }

  private bool m_wasHurting = false;

  public void UpdatePlayer (Player player)
  {
    m_Player = player;
  }

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
  }

  void Die()
  {
    Instantiate(deathEffect, transform.position, Quaternion.identity);
    m_Player.Game.End ();
    Destroy(gameObject);
  }
}
