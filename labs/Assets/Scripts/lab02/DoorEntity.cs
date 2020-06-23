using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEntity : OpenableEntity
{
    public DoorEntity (EscapeGame game, string name, string identifier, Vector3 position) 
    : base(game, name, identifier, position) {}
    public override void Interact(Entity entity = null)
    {
        Debug.Log ("You found an exit!");
        Game.Finish();
    }
}
