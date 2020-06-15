using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEntity : MonoBehaviour
{
  [SerializeField] float speed = 20f;
  [SerializeField] int damage = 40;
  [SerializeField] Rigidbody2D rb;
  [SerializeField] GameObject impactEffect;

  // Start is called before the first frame update
  void Start()
  {
    rb.velocity = transform.right * speed;
  }

  void OnTriggerEnter2D (Collider2D hitInfo)
  {
    Health player = hitInfo.GetComponent <Health> ();
    if (player != null)
    {
      player.TakeDamage (damage);
    }
    Instantiate (impactEffect, transform.position, transform.rotation);
    Destroy (gameObject);
  }
}
