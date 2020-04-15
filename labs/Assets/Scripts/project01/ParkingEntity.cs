using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingEntity : MonoBehaviour
{
    public ParkingAreaEntity parkingArea;

    public float MAX_POINTS = 15;
    float POINTS_REDUCTION = 5;
    float m_Points;
    public float Points { get {return m_Points;} }

    bool m_IsParked = false;
    public bool isParked { get { return m_IsParked; } set { m_IsParked = value; } }
    [SerializeField] DeductionEntity[] m_Deductions = new DeductionEntity[3];
    // Start is called before the first frame update
    void OnEnable()
    {
        m_Points = MAX_POINTS;
        m_IsParked = false;
        EnableParkingEntity();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_IsParked)
        {
            StartCoroutine(DisableParkingEntity());
        }
    }

    void EnableParkingEntity ()
    {
        parkingArea.gameObject.SetActive(true);
        foreach (DeductionEntity deduction in m_Deductions)
        {
            deduction.enabled = true;
        }
    }

    IEnumerator DisableParkingEntity ()
    {
        yield return new WaitForSeconds(1);
        parkingArea.Reset();
        parkingArea.gameObject.SetActive(false);
        foreach (DeductionEntity deduction in m_Deductions)
        {
            deduction.enabled = false;
        }
    }
}
