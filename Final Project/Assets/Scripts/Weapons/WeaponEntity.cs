using UnityEngine;

public class WeaponEntity : MonoBehaviour
{
  [SerializeField] int damage = 40;
  [SerializeField] GameObject impactEffect;
  [SerializeField] bool m_IsReusable = true;

  virtual protected void Initial () {}
  virtual public void Trigger (HealthBehavior playerHealth)
  {
    if (playerHealth != null)
    {
      playerHealth.TakeDamage (damage);
    }
    Instantiate (impactEffect, transform.position, transform.rotation);
    if (!m_IsReusable) Destroy (gameObject);
  }

  void Start ()
  {
    Initial ();
  }

  void OnTriggerEnter2D (Collider2D hitInfo)
  {
    HealthBehavior playerHealth = hitInfo.GetComponent <HealthBehavior> ();
    Trigger (playerHealth);
  }
}