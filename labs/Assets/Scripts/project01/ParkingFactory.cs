using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParkingFactory : MonoBehaviour
{
    [SerializeField] GameObject[] m_Parkings = new GameObject[18];

    [Range(0.0f, 1.0f)]
    public float parkingRatio = 0.5f;

    public Text parkingRemainUI;
    int m_ActiveParkingLengt;
    // Start is called before the first frame update
    void OnEnable()
    {
        m_ActiveParkingLengt = 0;
        foreach (GameObject parking in m_Parkings) { 
            if (Random.Range(0f, 1f) >= parkingRatio)
            {
                parking.SetActive(true);
                m_ActiveParkingLengt++;
            } else {
                parking.SetActive(false);
            }
        }
        UpdateUI();
    }
    void OnDisable()
    {
        foreach (GameObject parking in m_Parkings) parking.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    void UpdateUI ()
    {
        int parkedParkingLength = m_Parkings.Where(parking => 
            parking.activeSelf &&
            parking.GetComponent <ParkingEntity> ().isParked
        ).ToArray().Length;
        parkingRemainUI.text = string.Format(
            "{0:D} / {1:D}", 
            m_ActiveParkingLengt - parkedParkingLength, 
            m_ActiveParkingLengt
        );
    }
}
