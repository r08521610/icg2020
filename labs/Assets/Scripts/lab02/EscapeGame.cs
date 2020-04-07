﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EscapeGame
{
    List<Entity> m_Entities = new List<Entity> ();

    int m_SelectedIndex = -1;
    Entity m_SelectedEntity = null;

    Entity m_TakenEntity = null;
    public Entity TakenEntity {get { return m_TakenEntity; }}

    public EscapeGame ()
    {
        MakeGame();
        Debug.Log("You are in a locked room. Do something to escape!");
        Debug.Log(
            "Press 'N' to select item; " +
            "'R' to putback taken item; " +
            "'Space' to inspect selected item; " +
            "'Enter' to interact with the selected item."
        );
    }
    void MakeGame ()
    {
        m_Entities.Add (new Entity ("Basketball"));
        m_Entities.Add (new Entity ("Chair"));
        m_Entities.Add (new Entity ("Cup"));
        m_Entities.Add (new DoorEntity ("Normal Door"));
        m_Entities.Add (new KeyEntity ("Gold Key", "123"));
        m_Entities.Add (new PaperEntity ("Yellow Old Paper", "There is a scary monster hidden behind a door with dark color."));
        m_Entities.Add (new BoxEntity (
            "A Wild Box is Appear", 
            new KeyEntity ("Platinum Key", "Open the Door!"),
            "123"
        ));
        m_Entities.Add (new MonsterDoorEntity ("Black Door"));
        m_Entities.Add (new ExitDoorEntity ("White Door", "Open the Door!"));
    }
    public void Inspect ()
    {
        if (m_SelectedEntity != null)
        {
            Debug.Log(string.Format("Inspect item <color=white>{0}</color>", m_SelectedEntity.Name));
            m_SelectedEntity.Inspect();
        } else {
            Debug.Log("You have to select a item first.");
        }
    }
    public void Interact ()
    {
        if (m_SelectedEntity != null)
        {
            Debug.Log(string.Format("Interact item <color=white>{0}</color>", m_SelectedEntity.Name));
            m_SelectedEntity.Interact(this);
        } else {
            Debug.Log("You have to select a item first.");
        }
    }
    public void Take (Entity entity) {
        if (m_TakenEntity != null)
        {
            Debug.Log (string.Format ("You already take item <color=white>{0}</color>", m_TakenEntity.Name));
        } else {
            Debug.Log (string.Format ("Take item <color=white>{0}</color>, press 'R' to put back.", entity.Name));
            m_TakenEntity = entity;
            m_Entities.Remove (entity);

            Deselect();
        }
    }
    public void Putback ()
    {
        if (m_TakenEntity != null)
        {
            Debug.Log (string.Format ("Put item <color=white>{0}</color> back.", m_TakenEntity.Name));
            m_Entities.Add (m_TakenEntity);

            m_TakenEntity = null;
        } else {
            Debug.Log ("You have nothing to put back.");
        }
    }

    public void SelectNext ()
    {
        if (m_Entities.Count == 0)
        {
            Deselect();
            Debug.Log("There is nothing in the room.");
            return;
        }
        if (++m_SelectedIndex >= m_Entities.Count)
        {
            m_SelectedIndex = 0;
        }
        m_SelectedEntity = m_Entities [m_SelectedIndex];
        Debug.Log(string.Format ("<color=white>{0}</color> has been selected.", m_SelectedEntity.Name));
    }
    void Deselect ()
    {
        m_SelectedIndex = -1;
        m_SelectedEntity = null;
    }

    public void Escape ()
    {
        Debug.Log ("<color=yellow>Congrats! You escape the room!</color>");
        Finish();
    }
    public void Die()
    {
        Debug.Log ("<color=red>Oops! You died.</color>");
        Finish();
    }
    public void Finish ()
    {
        Debug.Log("Thanks for playing the game");
        // UnityEditor.EditorApplication.isPlaying = false;
    }
}
