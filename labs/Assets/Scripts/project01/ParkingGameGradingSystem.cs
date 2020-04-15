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
    public float duration = 0.5f;
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

    public float GetCurrentPoints () => ParkingGamePointsInstance.Instance.Points;

    public void GainParkingPoints (float points) {
        var origin = ParkingGamePointsInstance.Instance.Points;
        ParkingGamePointsInstance.Instance.gainPoints (points);
        // UpdatePointsUI (ParkingGamePointsInstance.Instance.Points);
        StartCoroutine(PointsUIUpdatingEffect(origin, ParkingGamePointsInstance.Instance.Points));
    }
    public void LoseDeductionPoints () {
        var origin = ParkingGamePointsInstance.Instance.Points;
        ParkingGamePointsInstance.Instance.losePoints (DEDUCTION_LOSE_POINTS);
        // UpdatePointsUI (ParkingGamePointsInstance.Instance.Points);
        StartCoroutine(PointsUIUpdatingEffect(origin, ParkingGamePointsInstance.Instance.Points));
    }
    public void Reset ()
    {
        var origin = ParkingGamePointsInstance.Instance.Points;
        ParkingGamePointsInstance.Instance.reset();
        StartCoroutine(PointsUIUpdatingEffect(origin, ParkingGamePointsInstance.Instance.Points));
    }

    void UpdatePointsUI (float points)
    {
        foreach (Text pointsUI in m_PointsUI)
        {
            pointsUI.text = points.ToString();
        }
    }

    IEnumerator PointsUIUpdatingEffect (float origin, float current)
    {
        for (float i = 0; i < duration; i += Time.deltaTime)
        {
            UpdatePointsUI(Mathf.Lerp(origin, current, i / duration));
            yield return null;
        }
        UpdatePointsUI(current);
    }
}
