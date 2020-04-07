using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEntity : OpenableEntity
{
    public DoorEntity (string name, string identifier = null) : base(name, identifier) {}
    // public override void Interact(EscapeGame game)
    // {
    //     Debug.Log ("You found an exit!");
    //     game.Finish();
    // }
}
