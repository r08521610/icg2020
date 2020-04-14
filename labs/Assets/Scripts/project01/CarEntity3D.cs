using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEntity3D : MonoBehaviour
{
  public GameObject wheelFrontRight;
  public GameObject wheelFrontLeft;
  public GameObject wheelBackRight;
  public GameObject wheelBackLeft;

  // Steering
  public float m_FrontWheelAngle = 0;
  const float WHEEL_ANGLE_LIMIT = 30f;
  public float turnAngularVelocity = 10f;
  public float autoTurnBackAngularVelocity = 20f;

  float carLength = 0.275f;

  // Accelerate and Decelerate
  public float m_Velocity = 0;

  float acceleration = 3f;
  float decceleration = 10f;
  float frictionDecceleration = 1f;
  float maxVelocity = 10f;
  float minVelocity = -10f;
  float m_DeltaMovement;


  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void FixedUpdate()
  {
    var deltaTime = Time.fixedDeltaTime;

    if (Input.GetKey (KeyCode.UpArrow))
    {
      if (m_Velocity >= 0)
        // Speed up
        m_Velocity = Mathf.Min (maxVelocity, m_Velocity + deltaTime * acceleration);
      else
        // Break down
        m_Velocity = Mathf.Min (0, m_Velocity + deltaTime * decceleration);
    } 
    if (Input.GetKey (KeyCode.DownArrow))
    {
      if (m_Velocity <= 0)
        // Speed up
        m_Velocity = Mathf.Max (minVelocity, m_Velocity - deltaTime * acceleration);
      else
        // Break down
        m_Velocity = Mathf.Max (0, m_Velocity - deltaTime * decceleration);
    }
    
    if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
    {
      if (Input.GetKey(KeyCode.RightArrow))
      {
        // Turn right
        m_FrontWheelAngle = Mathf.Clamp(
          m_FrontWheelAngle + deltaTime * turnAngularVelocity,
          -WHEEL_ANGLE_LIMIT,
          WHEEL_ANGLE_LIMIT
        );
        UpdateWheels();
      }
      if (Input.GetKey(KeyCode.LeftArrow))
      {
        // Turn left
        m_FrontWheelAngle = Mathf.Clamp(
          m_FrontWheelAngle - deltaTime * turnAngularVelocity,
          -WHEEL_ANGLE_LIMIT,
          WHEEL_ANGLE_LIMIT
        );
        UpdateWheels();
      }
    } else
    {
      if (m_FrontWheelAngle > 0)
        m_FrontWheelAngle = Mathf.Max(
          m_FrontWheelAngle - deltaTime * autoTurnBackAngularVelocity,
          0
        );
      else
        m_FrontWheelAngle = Mathf.Min(
          m_FrontWheelAngle + deltaTime * autoTurnBackAngularVelocity,
          0
        );
      UpdateWheels();
    }

    UpdateCarTransform();
  }

  void UpdateWheels ()
  {
      // Update wheels by m_FrontWheelAngle
    Vector3 localEulerAngles = new Vector3(0f, m_FrontWheelAngle, 0f);
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
          m_Velocity = Mathf.Max(0, m_Velocity - frictionDecceleration * Time.fixedDeltaTime);
      } else 
      {
          m_Velocity = Mathf.Min(0, m_Velocity + frictionDecceleration * Time.fixedDeltaTime);
      }
    }
    m_DeltaMovement = m_Velocity * Time.fixedDeltaTime;

    if (m_DeltaMovement != 0) this.transform.Rotate (
      0f,
      1 / carLength *
      Mathf.Tan (Mathf.Deg2Rad * m_FrontWheelAngle) *
      m_DeltaMovement *
      Mathf.Rad2Deg,
      0f
    );
    this.transform.Translate (Vector3.right * m_DeltaMovement);
  }
}
