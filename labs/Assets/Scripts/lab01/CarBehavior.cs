using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehavior : MonoBehaviour
{
    [Range(0.0f, 10.0f)]
    public float countDown = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void Destroy()
    {
        Destroy(this.gameObject, countDown);
    }

    void OnMouseOver() 
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject.Find("GameManager").SendMessage("setCurrentCar", this);
        }
    }
}
