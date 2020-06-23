using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lab07;

public class EscapeGameScene : MonoBehaviour
{
    [SerializeField] GameUI m_GameUI;
    EscapeGame m_Game;
    public EscapeGame Game { get { return m_Game; } }
    const float SELECT_RANGE = 3;
    // Start is called before the first frame update
    void Awake ()
    {
        m_Game = new EscapeGame();
        m_Game.OnGameStarted += HandleOnGameStarted;
        m_Game.OnGameFinished += HandleOnGameFinished;
        m_Game.OnGameOver += HandleOnGameOver;

        m_Game.OnMessageAdded += HandleOnMessageAdded;

        m_Game.OnEntityInteracted += HandleOnEntityInteracted;
        m_Game.OnEntityInspected += HandleOnEntityInspected;
        m_Game.OnEntitySelected += HandleOnEntitySelected;
        m_Game.OnEntityDeselected += HandleOnEntityDeselected;
        m_Game.OnEntityTaken += HandleOnEntityTaken;
        m_Game.OnEntityReleased += HandleOnEntityReleased;

        m_Game.MakeGame ();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown (KeyCode.Space))
        {
            DetectEntity ();
        }

        // if (Input.GetKeyDown (KeyCode.N))
        // {
        //     m_Game.SelectNext();
        // } else if (Input.GetKeyDown (KeyCode.Space))
        // {
        //     m_Game.Inspect ();
        // } else if (Input.GetKeyDown (KeyCode.Return))
        // {
        //     m_Game.Interact();
        // } else if (Input.GetKeyDown (KeyCode.R))
        // {
        //     m_Game.Putback();
        // }
    }

    #region Message Event Handlers
    void HandleOnMessageAdded (string message) { m_GameUI.ShowMessage (message); }
    #endregion

    #region Entity Event Handlers
    void HandleOnEntitySelected (Entity entity) {
        m_GameUI.SetActionVisible (true);
    }
    void HandleOnEntityDeselected (Entity entity) {
        m_GameUI.SetActionVisible (false);
    }
    void HandleOnEntityTaken (Entity entity) {
        m_GameUI.SetActionVisible (false);
        m_GameUI.UpdateTakenEntities ();
    }
    void HandleOnEntityReleased (Entity entity) {
        m_GameUI.UpdateTakenEntities ();

        var entityBehav = GameObject.Instantiate (
            Resources.Load <EntityBehav> ("Prefabs/" + entity.Prefabs)
        );
        entityBehav.transform.localPosition = entity.Position;
        entityBehav.UpdateEntity (entity);
    }
    void HandleOnEntityInteracted (Entity entity) {}
    void HandleOnEntityInspected (Entity entity) {}
    #endregion

    #region Game Event Handlers
    void HandleOnGameStarted (EscapeGame game) {
        foreach (var entity in m_Game.Entities)
        {
            var entityBehav = GameObject.Instantiate (
                Resources.Load <EntityBehav> ("Prefabs/" + entity.Prefabs)
            );
            entityBehav.transform.localPosition = entity.Position;
            entityBehav.UpdateEntity (entity);
        }
    }
    void HandleOnGameFinished (EscapeGame game) {}
    void HandleOnGameOver (EscapeGame game) {}
    #endregion

    void DetectEntity ()
    {
        Ray ray = new Ray (Camera.main.transform.position, Camera.main.transform.forward);

        bool detectEntity = false;

        RaycastHit raycastResult;
        if (Physics.Raycast (ray, out raycastResult))
        {
            if (raycastResult.distance < SELECT_RANGE)
            {
                var entityBehav = raycastResult.collider.GetComponent <EntityBehav> ();
                if (entityBehav != null)
                {
                    detectEntity = true;
                    m_Game.SelectEntity (entityBehav.Entity);
                }
            }
        }
        if (!detectEntity)
        {
            SelectNothing ();
        }
    }
    void SelectNothing ()
    {
        m_Game.SelectEntity (null);
    }
}
