using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxEntity : OpenableEntity
{
    Entity m_Content;
    bool m_Closed = true;
    public BoxEntity (string name, Entity content, string keyIdentifier)
    : base (name, keyIdentifier) {
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
    public override void Interact(EscapeGame game)
    {
        game.Putback();
        game.Take(m_Content);
    }
    protected override void Open(EscapeGame game)
    {
        m_Closed = false;
        Debug.Log("Box is opened.");
        game.Putback();
        game.Take(m_Content);
    }
}
