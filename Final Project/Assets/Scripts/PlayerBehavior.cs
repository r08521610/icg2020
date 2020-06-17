using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
  [SerializeField] PlayerMovement m_PlayerMovement;
  [SerializeField] AttackBehavior m_AttackBehavior;

  Player m_Player;
  public Player Player { get { return m_Player; } }

  void Awake()
  {
    m_PlayerMovement.enabled = true;
    m_AttackBehavior.enabled = true;
  }

  public void UpdatePlayer (Player player)
  {
    m_Player = player;

    m_Player.OnEnable += HandleOnEnable;
    m_Player.OnDisable += HandleOnDisable;
    m_Player.OnDead += HandleOnDead;
  }

  void OnDestroy ()
  {
    if (m_Player != null)
    {
      m_Player.OnEnable -= HandleOnEnable;
      m_Player.OnDisable -= HandleOnDisable;
      m_Player.OnDead -= HandleOnDead;
    }
  }

  #region Event Handlers
  void HandleOnEnable(Player p) 
  {
    m_PlayerMovement.enabled = true;
    m_AttackBehavior.enabled = true;
  }
  void HandleOnDisable(Player p)
  {
    m_PlayerMovement.enabled = false;
    m_AttackBehavior.enabled = false;
  }
  void HandleOnDead(Player p)
  {
    Destroy (gameObject);
  }
  #endregion
}
