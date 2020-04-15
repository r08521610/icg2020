using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeductionEntity : MonoBehaviour
{
    MeshRenderer m_DeductionRenderer;

    // Start is called before the first frame update
    void OnEnable ()
    {
        m_DeductionRenderer = this.GetComponent <MeshRenderer> ();
        ChangeColor (Color.white);
    }
    void OnDisable ()
    {
        ChangeColor(Color.grey);
    }

    void OnCollisionEnter (Collision collision)
    {
        if (this.enabled)
        {
            ChangeColor (Color.red);
            ParkingGameGradingSystem.Instance.LoseDeductionPoints();
        }
    }

    void OnCollisionExit (Collision collision)
    {
        if (this.enabled) ChangeColor (Color.white);
    }

    void ChangeColor (Color color)
    {
        m_DeductionRenderer.material.color = color;
    }
}
