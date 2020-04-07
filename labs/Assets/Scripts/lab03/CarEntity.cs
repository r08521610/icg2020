using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEntity : MonoBehaviour
{
    public GameObject wheelFrontRight;
    public GameObject wheelFrontLeft;
    public GameObject wheelBackRight;
    public GameObject wheelBackLeft;

    float carLength = 1f;

    float m_FrontWheelAngle = 0;
    const float WHEEL_ANGLE_LIMIT = 20f;
    float turnAngularVelocity = 10f;

    // Accelerate and decelerate
    float m_Velocity;
    public float Velocity { get {return m_Velocity;} }
    float acceleration = 3f;
    float decceleration = 3f;
    float frictionDecceleration = 1f;
    float maxVelocity = 6f;
    float minVelocity = -6f;
    float m_DeltaMovement;

    // Start is called before the first frame update
    void Start()
    {
        m_Velocity = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey (KeyCode.UpArrow))
        {
            // Speed up
            m_Velocity = Mathf.Min (maxVelocity, m_Velocity + Time.deltaTime * acceleration);
        } 
        if (Input.GetKey (KeyCode.DownArrow))
        {
            // Break
            m_Velocity = Mathf.Max (minVelocity, m_Velocity - Time.deltaTime * decceleration);
        }
        if (Input.GetKey (KeyCode.LeftArrow))
        {
            // Turn Left
            m_FrontWheelAngle = Mathf.Clamp (
                m_FrontWheelAngle + Time.deltaTime * turnAngularVelocity,
                -WHEEL_ANGLE_LIMIT,
                WHEEL_ANGLE_LIMIT
            );
            UpdateWheels();
        }
        if (Input.GetKey (KeyCode.RightArrow))
        {
            // Turn Right
            m_FrontWheelAngle = Mathf.Clamp (
                m_FrontWheelAngle - Time.deltaTime * turnAngularVelocity,
                -WHEEL_ANGLE_LIMIT,
                WHEEL_ANGLE_LIMIT
            );
            UpdateWheels();
        }
        UpdateCarTransform();
    }

    void UpdateWheels ()
    {
        // Update wheels by m_FrontWheelAngle
        Vector3 localEulerAngles = new Vector3(0f, 0f, m_FrontWheelAngle);
        wheelFrontLeft.transform.localEulerAngles = localEulerAngles;
        wheelFrontRight.transform.localEulerAngles = localEulerAngles;
    }
    void UpdateCarTransform ()
    {
        if (m_Velocity != 0)
        {
            bool isForward = m_Velocity > 0;
            if (isForward)
            {
                m_Velocity = Mathf.Max(0, m_Velocity - frictionDecceleration * Time.deltaTime);
            } else 
            {
                m_Velocity = Mathf.Min(0, m_Velocity + frictionDecceleration * Time.deltaTime);
            }
        }
        m_DeltaMovement = m_Velocity * Time.deltaTime;

        if (m_DeltaMovement != 0) this.transform.Rotate (0f, 0f,
            1 / carLength *
            Mathf.Tan (Mathf.Deg2Rad * m_FrontWheelAngle) *
            Mathf.Rad2Deg
        );
        this.transform.Translate (Vector3.up * m_DeltaMovement);
    }
}
