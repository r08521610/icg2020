using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxEntity : OpenableEntity
{
    Entity m_Content;
    bool m_Closed = true;
    public BoxEntity (EscapeGame game, string name, Entity content, string keyIdentifier, Vector3 position)
    : base (game, name, keyIdentifier, position) {
        m_Content = content;
    }
    public override void Inspect()
    {
        if (m_Closed)
        {
            Debug.Log ("<color=red>Box is Locked! Use key to open it.</color>");
        } else {
            m_Content.Inspect();
        }
    }
    public override void Interact(Entity entity = null)
    {
        // game.Putback();
        // game.Take(m_Content);
        if (m_Closed)
        {
            m_Closed = false;
        } else {
            if (m_Content == null)
            {
                base.Interact (entity);
            } else {
                m_Content.Interact (entity);
            }
        }
    }
    protected override void Open()
    {
        m_Closed = false;
        Debug.Log("Box is opened.");
        // Game.Putback();
        Game.Take(m_Content);
    }
}
