using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
  public delegate void PlayerEvent (Player p);
  public event PlayerEvent OnEnable = (p) => {};
  public event PlayerEvent OnDisable = (p) => {};
  public event PlayerEvent OnDead = (p) => {};

  string m_Prefab = "Sniper";  
  public string Prefab { get { return m_Prefab; } }

  Game m_Game;
  public Game Game { get { return m_Game; } }
  
  public Player (Game game, string prefab)
  {
    m_Game = game;
    m_Prefab = prefab;
  }

  public void Die ()
  {
    OnDead (this);
  }
}
