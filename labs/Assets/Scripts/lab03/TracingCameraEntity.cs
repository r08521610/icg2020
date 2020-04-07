using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TracingCameraEntity : MonoBehaviour
{
    public CarEntity targetObject;
    public float MOVING_THRESHOLD = 1f;

    Camera m_Camera;
    float m_OrthographicSize;
    // Start is called before the first frame update
    void Start()
    {
        m_Camera = this.GetComponent <Camera> ();
        m_OrthographicSize = m_Camera.orthographicSize;
    }

    // Update is called once per frame
    void LateUpdate()
    {   
        Vector2 deltaPos = this.transform.position - targetObject.transform.position;
        m_Camera.orthographicSize = m_OrthographicSize + targetObject.Velocity * 0.05f;
        if (deltaPos.magnitude > MOVING_THRESHOLD) {
            deltaPos.Normalize ();
            Vector2 newPosition = new Vector2 (targetObject.transform.position.x, targetObject.transform.position.y) + deltaPos * MOVING_THRESHOLD;
            this.transform.position = new Vector3 (newPosition.x, newPosition.y, this.transform.position.z);
            this.transform.localEulerAngles = new Vector3(targetObject.transform.localEulerAngles.x, targetObject.transform.localEulerAngles.y, this.transform.localEulerAngles.z);
        }
    }
}
