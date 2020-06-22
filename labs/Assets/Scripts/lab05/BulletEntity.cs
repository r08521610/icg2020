using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEntity : MonoBehaviour
{
    [SerializeField] float m_Speed = 20f;
    [SerializeField] Rigidbody m_RigidBody;
    [SerializeField] GameObject m_ExplosionEffect;
    // Start is called before the first frame update
    void Awake()
    {
        m_RigidBody.velocity = transform.right * m_Speed;
    }

    void OnTriggerEnter (Collider collider)
    {
        Instantiate (m_ExplosionEffect, collider.gameObject.transform.position, collider.gameObject.transform.rotation);
        // Destroy (this);
    }
}
