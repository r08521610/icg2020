using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointFactory : MonoBehaviour
{
    int MAX_CHECKPOINTS_AMOUNT = 10;
    List<GameObject> checkpoints = new List <GameObject> ();
    // Start is called before the first frame update
    void Start()
    {
        CreateCheckPoints();
    }

    // Update is called once per frame
    void Update()
    {
        if (checkpoints.Count <= 0) CreateCheckPoints();
    }

    void CreateCheckPoints () 
    {
        var checkpointPrefab = Resources.Load<GameObject>("Prefabs/barrel");
        for (int i = 0; i < MAX_CHECKPOINTS_AMOUNT; i++)
        {
            GameObject checkpoint = GameObject.Instantiate(checkpointPrefab, new Vector3(Random.Range(-20,20), Random.Range(-20,20), 0), Quaternion.identity);
            checkpoints.Add(checkpoint);
        }
    }
}
