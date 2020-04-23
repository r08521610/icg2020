using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AircraftEntity : MonoBehaviour
{
    // Plane Velocity
    public float m_Velocity = 10;
    const float PLANE_ACCELERATION = 10f;
    const float PLANE_DECELERATION = 10f;
    const float PLANE_MIN_VELOCITY = 10f;
    const float PLANE_MAX_VELOCITY = 50f;

    // Roll Velocity
    public float m_RollVelocity;
    const float ROLL_ACCELERATION = 100f;
    const float ROLL_DECELERATION = 100f;
    const float MAX_ROLL_VELOCITY = 100f;
    
    // Pitch Velocity
    public float m_PitchVelocity;
    const float PITCH_ACCELERATION = 100f;
    const float PITCH_DECELERATION = 100f;
    const float MAX_PITCH_VELOCITY = 100f;

    [SerializeField] Transform m_PlaneBodyTrans;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        // Roll
        this.transform.Rotate (m_RollVelocity * Time.fixedDeltaTime, 0, 0);
        // Pitch
        this.transform.Rotate (0, 0, m_PitchVelocity * Time.fixedDeltaTime);
        // Fly forward
        this.transform.Translate (m_Velocity * Time.fixedDeltaTime * Vector3.right);

        // Update plane body for rolling and pitching effects
        m_PlaneBodyTrans.localEulerAngles = new Vector3 (
            m_RollVelocity / MAX_ROLL_VELOCITY * 30f,
            0f,
            m_PitchVelocity / MAX_PITCH_VELOCITY * 30f
        );
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey (KeyCode.LeftShift))
        {
            // Break
            m_Velocity = Mathf.Max (m_Velocity - PLANE_DECELERATION * Time.deltaTime, PLANE_MIN_VELOCITY);
        } else if (Input.GetKey (KeyCode.Space)) {
            // Speed up
            m_Velocity = Mathf.Min (m_Velocity + PLANE_ACCELERATION * Time.deltaTime, PLANE_MAX_VELOCITY);
        }

        if (Input.GetKey (KeyCode.LeftArrow))
        {
            // Roll counterclockwise

            m_RollVelocity = Mathf.Max (MAX_ROLL_VELOCITY, m_RollVelocity + ROLL_ACCELERATION * Time.deltaTime);
        } else if (Input.GetKey (KeyCode.RightArrow)) {
            // Roll clockwise
            m_RollVelocity = Mathf.Min (-MAX_ROLL_VELOCITY, m_RollVelocity - ROLL_ACCELERATION * Time.deltaTime);
        } else {
            // Recover from rolling
            m_RollVelocity = m_RollVelocity > 0 ?
                Mathf.Max (0, m_RollVelocity - ROLL_ACCELERATION * Time.deltaTime) :
                Mathf.Min (0, m_RollVelocity + ROLL_ACCELERATION * Time.deltaTime);
        }

        if (Input.GetKey (KeyCode.DownArrow))
        {
            // Pitch down
            m_PitchVelocity = Mathf.Min (-MAX_PITCH_VELOCITY, m_PitchVelocity - PITCH_ACCELERATION * Time.deltaTime);
        } else if (Input.GetKey (KeyCode.UpArrow)) {
            // Pitch up
            m_PitchVelocity = Mathf.Max (MAX_PITCH_VELOCITY, m_PitchVelocity - PITCH_ACCELERATION * Time.deltaTime);
        } else {
            // Recover from rolling
            m_PitchVelocity = m_PitchVelocity > 0 ?
                Mathf.Max (0, m_PitchVelocity - PITCH_ACCELERATION * Time.deltaTime) :
                Mathf.Min (0, m_PitchVelocity + PITCH_ACCELERATION * Time.deltaTime);
        }
    }
}
