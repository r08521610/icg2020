using UnityEngine;

public class BulletEntity : WeaponEntity
{
  [SerializeField] float speed = 20f;
  [SerializeField] Rigidbody2D rb;

  override protected void Initial ()
  {
    rb.velocity = transform.right * speed;
  }

  override public void Interact()
  {
    Instantiate (impactEffect, transform.position, transform.rotation);
    Destroy (gameObject);
  }
}
