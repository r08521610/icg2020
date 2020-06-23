using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttackBehavior : AttackBehavior
{
  [SerializeField] SwordEntity m_Sword;

  override protected void Attack ()
  {
    RaycastHit2D[] hits = Physics2D.CircleCastAll (
      transform.position, m_Sword.WieldRadius, transform.right, 
      m_Sword.WieldRadius, m_Sword.AttackObject);
    foreach (RaycastHit2D hit in hits)
    {
      if (hit.collider.gameObject != gameObject)
      {
        HealthBehavior player = hit.collider.GetComponent <HealthBehavior> ();
        if (player != null) m_Sword.Trigger (player);

        Entity entity = hit.collider.GetComponent <Entity> ();
        if (entity != null) entity.Interact ();
      }
    }
  }

  override protected void ChargedAttack ()
  {
    RaycastHit2D[] hits = Physics2D.CircleCastAll (
      transform.position, m_Sword.WieldRadius, transform.right, 
      m_Sword.WieldRadius, m_Sword.AttackObject);
    foreach (RaycastHit2D hit in hits)
    {
      if (hit.collider.gameObject != gameObject)
      {
        HealthBehavior player = hit.collider.GetComponent <HealthBehavior> ();
        if (player != null) m_Sword.Trigger (player, m_ChargeIncreaseRatio);

        Entity entity = hit.collider.GetComponent <Entity> ();
        if (entity != null) entity.Interact ();
      }
    }
  }
}
