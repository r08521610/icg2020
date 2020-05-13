using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageAreaEntity : MonoBehaviour
{
    Color m_Color;
    List <GameObject> m_Objects = new List <GameObject> ();
    // Start is called before the first frame update
    void Start()
    {
        m_Color = Random.ColorHSV(0f, 1f, 0f, 1f, 0f, 1f);
        this.GetComponent <MeshRenderer> ().material.color = m_Color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter (Collider other)
    {
        other.transform.gameObject.GetComponent <MeshRenderer> ().material.color = m_Color;
        m_Objects.Add (other.transform.gameObject);
    }

    private void OnTriggerExit (Collider other)
    {
        other.transform.gameObject.GetComponent <MeshRenderer> ().material.color = Color.white;
        m_Objects.Remove (other.transform.gameObject);
    }
}
