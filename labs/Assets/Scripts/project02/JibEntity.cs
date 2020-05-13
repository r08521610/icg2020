using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project02;

public class JibEntity : MonoBehaviour
{
    const float MOVE_SPEED = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A)){
            // Project02.CameraCenter.Instance.TurnOnGodViewCam();
			transform.Rotate(MOVE_SPEED * Vector3.back * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.D)){
            // Project02.CameraCenter.Instance.TurnOnGodViewCam();
			transform.Rotate(MOVE_SPEED * Vector3.forward * Time.deltaTime);
		}
    }
}
