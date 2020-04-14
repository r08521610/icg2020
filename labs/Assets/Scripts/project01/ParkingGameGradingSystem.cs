using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ICG2020.Instance;

public class ParkingGameGradingSystem : MonoBehaviour
{
    private static ParkingGameGradingSystem _instance;
    public static ParkingGameGradingSystem Instance
    {
        get
        {
            if (_instance == null) _instance = new ParkingGameGradingSystem();
            return _instance;
        }
    }

    public float PARKING_POINTS = 15;
    public float DEDUCTION_LOSE_POINTS = 10;

    public Text[] m_PointsUI;
    // Start is called before the first frame update
    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy (this.gameObject);
        } else {
            _instance = this;
        }
        ParkingGamePointsInstance.Instance.reset();
    }

    // Update is called once per frame
    void Start()
    {
        UpdatePointsUI (ParkingGamePointsInstance.Instance.Points);
    }

    public void GainParkingPoints () {
        ParkingGamePointsInstance.Instance.gainPoints (PARKING_POINTS);
        UpdatePointsUI (ParkingGamePointsInstance.Instance.Points);
    }
    public void LoseDeductionPoints () {
        ParkingGamePointsInstance.Instance.losePoints (DEDUCTION_LOSE_POINTS);
        UpdatePointsUI (ParkingGamePointsInstance.Instance.Points);
    }

    void UpdatePointsUI (float points)
    {
        foreach (Text pointsUI in m_PointsUI)
        {
            pointsUI.text = points.ToString();
        }
    }
}
