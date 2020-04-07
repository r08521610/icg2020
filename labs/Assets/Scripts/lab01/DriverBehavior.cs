using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverBehavior : MonoBehaviour
{
    public string Name;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Player " + Name + " joined.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
