using UnityEngine;
public class SwordEntity : WeaponEntity
{
  [SerializeField] float m_WieldRadius = 1.9f;
  public float WieldRadius { get { return m_WieldRadius; } }
  [SerializeField] private LayerMask m_AttackObject;
  public LayerMask AttackObject { get { return m_AttackObject; } }
}
