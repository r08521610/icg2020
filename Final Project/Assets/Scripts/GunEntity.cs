using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEntity : MonoBehaviour
{
  [SerializeField] string m_ButtonKey = "Fire1";
  [SerializeField] Transform firePoint;
  [SerializeField] GameObject bulletPrefab;
  [SerializeField] Animator animator;

  private bool m_wasAttacking = false;
  private float m_TimeAfterAttack = 1f;

  // Update is called once per frame
  void Update()
  {
    if (m_wasAttacking) m_TimeAfterAttack -= Time.deltaTime;
    if (m_TimeAfterAttack < 0f)
    {
      animator.SetBool ("IsAttacking", false);
      m_wasAttacking = false;
    }

    if (Input.GetButtonDown(m_ButtonKey))
    {
      Shoot ();
      m_wasAttacking = true;
      m_TimeAfterAttack = 1f;
      animator.SetBool ("IsAttacking", true);
    }
  }

  void Shoot ()
  {
    Instantiate (bulletPrefab, firePoint.position, firePoint.rotation);
  }
}
