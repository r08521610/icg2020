using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[BoltGlobalBehaviour]
public class NetworkCallbacks : Bolt.GlobalEventListener
{
  public override void SceneLoadLocalDone(string scene)
  {
    Debug.Log ("Load Scene Done");
  }
}
