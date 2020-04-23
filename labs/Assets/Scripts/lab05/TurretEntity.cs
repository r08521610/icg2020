using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEntity : MonoBehaviour
{
    const float MAX_BASE_ROTATION_VELOCITY = 360f;
    const float MAX_GUN_ROTATION_VELOCITY = 90f;

    [SerializeField] GameObject m_Target;
    [SerializeField] GameObject m_Base;
    [SerializeField] GameObject m_Gun;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 diffVec = m_Target.transform.position - this.transform.position;

        var targetBaseQuaternion = Quaternion.FromToRotation (
            Vector3.left,
            new Vector3 (diffVec.x, 0f, diffVec.z)
        );

        m_Base.transform.localRotation = Quaternion.RotateTowards (
            m_Base.transform.rotation,
            targetBaseQuaternion,
            MAX_BASE_ROTATION_VELOCITY * Time.deltaTime
        );

        Vector2 xzProjection = new Vector2 (diffVec.x, diffVec.z);
        float xyProjectedLength = xzProjection.magnitude;

        var targetGunQuaternion = Quaternion.FromToRotation (
            new Vector3 (-xyProjectedLength, 0f, 0f),
            new Vector3 (-xyProjectedLength, diffVec.y, 0f)
        );
        m_Gun.transform.localRotation = Quaternion.RotateTowards (
            m_Gun.transform.localRotation,
            targetGunQuaternion,
            MAX_GUN_ROTATION_VELOCITY * Time.deltaTime
        );
    }
}
