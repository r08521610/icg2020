using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimitivesGenerator : MonoBehaviour
{
    [SerializeField] GameObject m_CubePrefab;
    [SerializeField] GameObject m_SpherePrefab;
    [SerializeField] Vector2 m_Dimension = new Vector2 (5, 5);

    GameObject m_ClickedObject;
    // Start is called before the first frame update
    void Start()
    {
        GeneratePrimitives (m_CubePrefab, Random.Range(5, 10));
        GeneratePrimitives (m_SpherePrefab, Random.Range(5, 10));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown (0))
        {
            FireRaycast ();
        } else if (Input.GetMouseButtonUp (0))
        {
            RecoverClickedObject ();
        }
    }

    void FireRaycast ()
    {
        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast (ray, out hit))
        {
            MeshRenderer renderer = hit.collider.GetComponent <MeshRenderer> ();
            if (renderer != null)
            {
                renderer.material.color = Color.red;
                m_ClickedObject = hit.collider.gameObject;
            }
        }
    }

    void RecoverClickedObject ()
    {
        if (m_ClickedObject != null)
        {
            m_ClickedObject.GetComponent <MeshRenderer> ().material.color = Color.white;
            m_ClickedObject = null;
        }
    }

    void GeneratePrimitives (GameObject primitive, int count)
    {
        for (int i = 0; i < count; i++)
        {
            var primitiveIns = GameObject.Instantiate (primitive);
            primitiveIns.transform.localPosition = new Vector3
            (
                Random.Range (-m_Dimension.x, m_Dimension.x),
                3f,
                Random.Range (-m_Dimension.y, m_Dimension.y)
            );
        }
    }
}
