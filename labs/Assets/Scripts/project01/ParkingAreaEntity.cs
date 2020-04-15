using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingAreaEntity : MonoBehaviour
{
    bool m_IsOccupied = false;
    public bool isOccupied { get {return m_IsOccupied;} }

    MeshRenderer m_ParkingAreaRenderer;

    // Start is called before the first frame update
    void OnEnable()
    {
        Reset();
    }

    void OnTriggerEnter (Collider other)
    {
        m_ParkingAreaRenderer.enabled = true;
        ChangeColor (Color.yellow);
    }
    void OnTriggerStay (Collider other)
    {
        bool prev_IsOccupied = m_IsOccupied;
        m_IsOccupied = Contains (this.GetComponent <BoxCollider> ().bounds, other.bounds);
        if (m_IsOccupied && !prev_IsOccupied) 
        {
            ParkingGameGradingSystem.Instance.GainParkingPoints(
                this.transform.parent.GetComponent <ParkingEntity> ().Points
            );
            ChangeColor (Color.green);
            this.transform.parent.GetComponent <ParkingEntity> ().isParked = true;
        }
        else if (!m_IsOccupied && prev_IsOccupied) ChangeColor (Color.yellow);
    }
    void OnTriggerExit (Collider other)
    {
        Reset();
    }

    public void Reset ()
    {
        m_ParkingAreaRenderer = this.GetComponent <MeshRenderer> ();
        m_ParkingAreaRenderer.enabled = false;
        m_IsOccupied = false;
        ChangeColor (Color.white);
    }

    void ChangeColor (Color color)
    {
        m_ParkingAreaRenderer.material.color = color;
    }

    bool Contains (Bounds parkingArea, Bounds car)
    {
        Rect parkingAreaRect = new Rect (parkingArea.min.x, parkingArea.min.z, parkingArea.extents.x * 2, parkingArea.extents.z * 2);
        Rect carRect = new Rect (car.min.x, car.min.z, car.extents.x * 2, car.extents.z * 2);
        return parkingAreaRect.Contains(new Vector2(carRect.xMin, carRect.yMin)) && 
            parkingAreaRect.Contains(new Vector2(carRect.xMin, carRect.yMax)) && 
            parkingAreaRect.Contains(new Vector2(carRect.xMax, carRect.yMin)) && 
            parkingAreaRect.Contains(new Vector2(carRect.xMax, carRect.yMax));
    }
}
