using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarFactory : MonoBehaviour
{
    public CarBehavior currentCar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            var carPrefab = Resources.Load<GameObject>("Prefabs/car");
            GameObject.Instantiate(carPrefab, Random.insideUnitCircle, Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.D) && currentCar)
        {
            currentCar.Destroy();
        }
    }

    void setCurrentCar(CarBehavior car)
    {
        currentCar = car;
        Debug.Log(currentCar);
    }
}
