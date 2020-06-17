using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game
{
  #region Events
  public delegate void GameEvent (Game game);

  public event GameEvent OnGameStarted = (g) => {};
  public event GameEvent OnGameEnded = (g) => {};
  #endregion

  List <Player> m_Players = new List <Player> (); 
  public List <Player> Players { get { return m_Players; } }

  public void MakeGame ()
  {
    OnGameStarted (this);
  }

  public void EnrollPlayer (Player player)
  {
    m_Players.Add (player);
  }

  public void End ()
  {
    OnGameEnded (this);
  }
}