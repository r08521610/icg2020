using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
  [SerializeField] GameScene m_GameScene;
  [SerializeField] GameObject m_LobbyUI;
  [SerializeField] GameObject m_SelectCharactersUI;
  [SerializeField] GameObject m_OnlineMenu;

  void Awake()
  {
    m_GameScene.Game.OnGameEnded += HandleOnGameEnded;
  }

  public void StartLocalGame ()
  {
    m_LobbyUI.SetActive (false);
    m_SelectCharactersUI.SetActive (true);
  }
  public void StartOnlineGame ()
  {
    m_LobbyUI.SetActive (false);
    m_OnlineMenu.SetActive (true);
  }
  public void BackToLobby ()
  {
    m_LobbyUI.SetActive (true);
    m_SelectCharactersUI.SetActive (false);
    m_OnlineMenu.SetActive (false);
  }

  public void StartGame ()
  {
    m_GameScene.Game.MakeGame ();
    m_SelectCharactersUI.SetActive (false);
  }

  #region Game Event Handlers
  void HandleOnGameEnded (Game game)
  {
    m_LobbyUI.SetActive (true);
  }
  #endregion
}
