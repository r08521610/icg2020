using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] bool m_Invincible = false;
    public bool IsInvincible { get { return m_Invincible; } }

    const float INVINCIBLE_INTERVAL = 10f;
    float m_InvincibleTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Invincible)
        {
            if (m_InvincibleTimer > INVINCIBLE_INTERVAL)
            {
                m_Invincible = false;
                this.GetComponent <MeshRenderer> ().material.color = new Color (67f / 255f, 167f / 255f, 59f / 255f);
            }

            m_InvincibleTimer += Time.deltaTime;
        }
    }

    void OnCollisionEnter (Collision collision)
    {
        var pill = collision.collider.gameObject.GetComponent <Pill> ();
        var ghost = collision.collider.gameObject.GetComponent <Ghost> ();

        if (pill != null) {
            Destroy (pill.gameObject);
            m_Invincible = true;
            this.GetComponent <MeshRenderer> ().material.color = Color.yellow;

            m_InvincibleTimer = 0;
        } else {
            if (ghost != null) {
                if (m_Invincible)
                {
                    Destroy (collision.gameObject);
                    Debug.Log ("You Win!!");
                    SceneManager.LoadScene("lab09");
                } else {
                    Destroy (this.gameObject);
                    Debug.Log ("You Loose");
                    SceneManager.LoadScene("lab09");
                }
            }
        }
    }
}
