using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordEntity : MonoBehaviour
{
  [SerializeField] string m_ButtonKey = "Fire2";
  [SerializeField] int damage = 60;
  [SerializeField] float m_WieldRadius = 1.9f;
  [SerializeField] private LayerMask m_AttackObject;
  [SerializeField] Animator animator;

  // Update is called once per frame
  void Update()
  {
    if (Input.GetButtonDown(m_ButtonKey))
    {
      Wield ();
      animator.SetBool ("IsAttacking", true);
    }
  }

  void Wield ()
  {
    RaycastHit2D[] hits = Physics2D.CircleCastAll (transform.position, m_WieldRadius, transform.right, m_WieldRadius, m_AttackObject);
    List <GameObject> gameObjects = new List <GameObject> ();
    foreach (RaycastHit2D hit in hits)
    {
      if (hit.collider.gameObject != gameObject && !gameObjects.Contains (hit.collider.gameObject))
      {
        gameObjects.Add (hit.collider.gameObject);
        Health player = hit.collider.GetComponent <Health> ();
        if (player != null) player.TakeDamage (damage);
      }
    }
  }

  public void OnWieldEnd ()
  {
    animator.SetBool ("IsAttacking", false);
  }
}
