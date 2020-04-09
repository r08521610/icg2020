using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleEntity : MonoBehaviour
{
    SpriteRenderer m_TargetRenderer;
    // Start is called before the first frame update
    void Start()
    {
        m_TargetRenderer = this.GetComponent <SpriteRenderer> ();
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        ChangeColor (Color.red);
    }
    void OnCollisionStay2D (Collision2D collision)
    {
        ChangeColor(Random.Range(0, 10) >= 5 ? Color.red : Color.green);
    }
    void OnCollisionExit2D (Collision2D collision)
    {
        ChangeColor (Color.white);
    }

    void ChangeColor (Color color)
    {
        m_TargetRenderer.color = color;
    }
}
