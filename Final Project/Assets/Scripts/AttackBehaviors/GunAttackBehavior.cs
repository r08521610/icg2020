using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAttackBehavior : AttackBehavior
{
  [SerializeField] Transform firePoint;
  [SerializeField] GameObject bulletPrefab;

  override protected void Attack ()
  {
    Instantiate (bulletPrefab, firePoint.position, firePoint.rotation);
  }
}
