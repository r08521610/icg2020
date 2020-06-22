using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCameraEntity : MonoBehaviour
{
    const float VELOCITY = 10;
    Vector3 m_MousePosition;
    float m_HorizontalAngle = 0;
    float m_VerticalAngle = 0;
    // Start is called before the first frame update
    void Start()
    {
        m_MousePosition = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown (0))
        {
            m_MousePosition = Input.mousePosition;
        } else if (Input.GetMouseButton (0))
        {
            Vector3 mouseDeltaPosition = m_MousePosition - Input.mousePosition;

            m_HorizontalAngle -= mouseDeltaPosition.x * 0.1f;
            m_VerticalAngle = Mathf.Clamp (m_VerticalAngle - mouseDeltaPosition.y * 0.1f, -89f, 89f);

            this.transform.localEulerAngles = new Vector3 (0f, m_HorizontalAngle, m_VerticalAngle);
            m_MousePosition = Input.mousePosition;
        }

        Vector3 movement = Vector3.zero;

        if (Input.GetKey (KeyCode.W))
        {
            movement += Vector3.right;
            // this.transform.Translate (VELOCITY * Time.deltaTime, 0, 0);
        } else if (Input.GetKey (KeyCode.S)) {
            movement += Vector3.left;
            // this.transform.Translate (-VELOCITY * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey (KeyCode.A))
        {
            movement += Vector3.forward;
            // this.transform.Translate (0, 0, VELOCITY * Time.deltaTime);
        } else if (Input.GetKey (KeyCode.D)) {
            movement += Vector3.back;
            // this.transform.Translate (0, 0, -VELOCITY * Time.deltaTime);
        }
        
        if (Input.GetKey (KeyCode.E))
        {
            movement += Vector3.up;
            // this.transform.Translate (0, VELOCITY * Time.deltaTime, 0);
        } else if (Input.GetKey (KeyCode.Q)) {
            movement += Vector3.down;
            // this.transform.Translate (0, -VELOCITY * Time.deltaTime, 0);
        }

        if (movement != Vector3.zero)
        {
            movement.Normalize ();
            this.transform.Translate (movement * VELOCITY * Time.deltaTime);
        }
    }
}
