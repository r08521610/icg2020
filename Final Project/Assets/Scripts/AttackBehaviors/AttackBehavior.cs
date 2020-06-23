using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehavior : MonoBehaviour
{
  [SerializeField] protected string m_ButtonKey = "Fire2";
  [SerializeField] protected Animator animator;
  [SerializeField] protected float m_ChargeTime = 2f;
  [SerializeField] protected float m_ChargeIncreaseRatio = 1.1f;
  private float m_ChargeTimer = 0f;

  virtual protected void Attack () {}
  virtual protected void ChargedAttack () { Debug.Log ("Charged Attack"); }
  virtual public void OnAttackEnd () {
    animator.SetBool ("IsAttacking", false);
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetButtonUp (m_ButtonKey))
    {
      if (m_ChargeTimer <= m_ChargeTime)
        Attack ();
      else ChargedAttack ();
      m_ChargeTimer = 0f;
      animator.SetBool ("IsAttacking", true);
    }
    if (Input.GetButton (m_ButtonKey))
    {
      m_ChargeTimer += Time.deltaTime;
    }
  }
}
