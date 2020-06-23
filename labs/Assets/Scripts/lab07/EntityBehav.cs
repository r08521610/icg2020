using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityBehav : MonoBehaviour
{
    MeshRenderer m_Renderer;
    Entity m_Entity;
    public Entity Entity { get { return m_Entity; } }
    // Start is called before the first frame update
    void Start()
    {
        m_Renderer = this.GetComponent <MeshRenderer> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateEntity (Entity entity)
    {
        m_Entity = entity;
        m_Entity.OnSelected +=  HandleOnSelected;
        m_Entity.OnDeselected += HandleOnDeselected;
        m_Entity.OnTaken += HandleOnTaken;
    }
    void OnDestroy ()
    {
        if (m_Entity != null)
        {
            m_Entity.OnSelected -=  HandleOnSelected;
            m_Entity.OnDeselected -= HandleOnDeselected;
            m_Entity.OnTaken -= HandleOnTaken;
        }
    }

    #region Event Handlers
    void HandleOnSelected (Entity e) { m_Renderer.material.color = Color.yellow; }
    void HandleOnDeselected (Entity e) { m_Renderer.material.color = Color.white; }
    void HandleOnTaken (Entity e) { Destroy (this.gameObject); }
    #endregion
}
