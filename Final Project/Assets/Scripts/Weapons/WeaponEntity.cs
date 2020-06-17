using UnityEngine;

public class WeaponEntity : Entity
{
  [SerializeField] int damage = 40;
  [SerializeField] protected GameObject impactEffect;
  [SerializeField] bool m_IsReusable = true;

  virtual protected void Initial () {}
  virtual public void Trigger (HealthBehavior playerHealth, float ratio=1f)
  {
    if (playerHealth != null)
    {
      playerHealth.TakeDamage ((int) Mathf.Round (damage * ratio));
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
    if (playerHealth != null) Trigger (playerHealth);
  }
}