using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingFactory : MonoBehaviour
{
    [SerializeField] GameObject[] m_Parkings = new GameObject[18];

    [Range(0.0f, 1.0f)]
    public float parkingRatio = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject parking in m_Parkings) parking.SetActive(Random.Range(0f, 1f) >= parkingRatio ? true : false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
