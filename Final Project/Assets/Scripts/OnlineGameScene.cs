using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlineGameScene : MonoBehaviour
{
  Game m_Game;
  public Game Game { get { return m_Game; } }

  void Awake()
  {
    m_Game = new Game();
    m_Game.OnGameStarted += HandleOnGameStarted;
    m_Game.OnGameEnded += HandleOnGameEnded;
  }

  void OnDestroy ()
  {
    if (m_Game != null)
    {
      m_Game.OnGameStarted -= HandleOnGameStarted;
      m_Game.OnGameEnded -= HandleOnGameEnded;
    }
  }

  #region Game Event Handlers
  void HandleOnGameStarted (Game game)
  {
    foreach (var player in m_Game.Players)
    {
      GameObject playerPrefab = GameObject.Instantiate (
        Resources.Load ("Prefabs/Player/" + player.Prefab)
      ) as GameObject;

      playerPrefab.GetComponent <PlayerBehavior> ().UpdatePlayer (player);
      playerPrefab.GetComponent <HealthBehavior> ().UpdatePlayer (player);
    }
  }
  void HandleOnGameEnded (Game game)
  {
    foreach (var player in m_Game.Players)
    {
      player.Die ();
    }
    m_Game.Players.Clear ();

    BoltNetwork.Shutdown ();
    BoltNetwork.LoadScene ("Lobby");
  }
  #endregion
}
