using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project02;
public class TrolleyEntity : MonoBehaviour
{
    const float MOVE_SPEED = 3f;

    ConfigurableJoint m_JointForHook;
    Rigidbody m_Rigidbody;

    [SerializeField] LineRenderer m_Cable;
    // Start is called before the first frame update
    void Start()
    {
        m_JointForHook = this.GetComponent <ConfigurableJoint> ();
        m_Rigidbody = this.GetComponent <Rigidbody> ();
        if (m_Cable == null) {
			m_Cable = gameObject.AddComponent<LineRenderer>();
		}
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCable ();

        if (Input.GetKey (KeyCode.Q))
        {
            var limit = m_JointForHook.linearLimit;
            limit.limit -= MOVE_SPEED * Time.deltaTime;
            m_JointForHook.linearLimit = limit;
            m_Rigidbody.WakeUp ();
        }
        if (Input.GetKey (KeyCode.E))
        {
            var limit = m_JointForHook.linearLimit;
            limit.limit += MOVE_SPEED * Time.deltaTime;
            m_JointForHook.linearLimit = limit;
            m_Rigidbody.WakeUp ();
        }

        if(Input.GetKey(KeyCode.W) && transform.localPosition.y > -17f)
        {
			transform.Translate(MOVE_SPEED * Vector3.down * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.S) && transform.localPosition.y < 3f)
        {
			transform.Translate(MOVE_SPEED * Vector3.up * Time.deltaTime);
		}
    }

    void UpdateCable ()
    {
        m_Cable.SetPosition (0, this.transform.position);

        var connectedBodyTransform = m_JointForHook.connectedBody.transform;
        m_Cable.SetPosition (1, connectedBodyTransform.TransformPoint (m_JointForHook.connectedAnchor));
    }
}
