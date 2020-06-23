using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAttackBehavior : AttackBehavior
{
  [SerializeField] Transform firePoint;
  [SerializeField] GameObject bulletPrefab;
  [SerializeField] GameObject chargedBulletPrefab;

  override protected void Attack ()
  {
    Instantiate (bulletPrefab, firePoint.position, firePoint.rotation);
  }
  override protected void ChargedAttack ()
  {
    Instantiate (chargedBulletPrefab, firePoint.position, firePoint.rotation);
  }
}
