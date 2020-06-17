using UnityEngine;
using Bolt;
using Bolt.Matchmaking;
using UdpKit;

public class OnlineGameMenu : GlobalEventListener
{
  public void StartServer ()
  {
    BoltLauncher.StartServer ();
  }

  public void StartClient ()
  {
    BoltLauncher.StartClient ();
  }

  public override void BoltStartDone ()
  {
    if (BoltNetwork.IsServer)
    {
      string matchName = "Rainforest";

      BoltMatchmaking.CreateSession (
        sessionID: matchName,
        sceneToLoad: "OnlineGame"
      );
    }
  }

  public override void SessionListUpdated(UdpKit.Map<System.Guid, UdpKit.UdpSession> sessionList)
  {
    foreach (var session in sessionList)
    {
      UdpSession photonSession = session.Value as UdpSession;

      if (photonSession.Source == UdpSessionSource.Photon)
      {
        BoltMatchmaking.JoinSession (photonSession);
      }
    }
  }
}
