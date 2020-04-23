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
        Vector3 mouseDeltaPosition = m_MousePosition - Input.mousePosition;

        m_HorizontalAngle -= mouseDeltaPosition.x * 0.1f;
        m_VerticalAngle = Mathf.Clamp (m_VerticalAngle - mouseDeltaPosition.y * 0.1f, -89f, 89f);

        this.transform.localEulerAngles = new Vector3 (0f, m_HorizontalAngle, m_VerticalAngle);
        m_MousePosition = Input.mousePosition;

        if (Input.GetKey (KeyCode.W))
        {
            this.transform.Translate (VELOCITY * Time.deltaTime, 0, 0);
        } else if (Input.GetKey (KeyCode.S)) {
            this.transform.Translate (-VELOCITY * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey (KeyCode.A))
        {
            this.transform.Translate (0, 0, VELOCITY * Time.deltaTime);
        } else if (Input.GetKey (KeyCode.D)) {
            this.transform.Translate (0, 0, -VELOCITY * Time.deltaTime);
        }
        
        if (Input.GetKey (KeyCode.E))
        {
            this.transform.Translate (0, VELOCITY * Time.deltaTime, 0);
        } else if (Input.GetKey (KeyCode.Q)) {
            this.transform.Translate (0, -VELOCITY * Time.deltaTime, 0);
        }
    }
}
