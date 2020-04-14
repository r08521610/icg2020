using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeductionEntity : MonoBehaviour
{
    MeshRenderer m_DeductionRenderer;
    // Start is called before the first frame update
    void Start()
    {
        m_DeductionRenderer = this.GetComponent <MeshRenderer> ();
    }

    void OnCollisionEnter (Collision collision)
    {
        ChangeColor (Color.red);
        ParkingGameGradingSystem.Instance.LoseDeductionPoints();
    }

    void OnCollisionExit (Collision collision)
    {
        ChangeColor (Color.white);
    }

    void ChangeColor (Color color)
    {
        m_DeductionRenderer.material.color = color;
    }
}
