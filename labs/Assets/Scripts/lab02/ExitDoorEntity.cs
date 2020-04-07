using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoorEntity : DoorEntity
{
    public ExitDoorEntity (string name, string identifier = null) : base (name, identifier) {}
    // public override void Interact(EscapeGame game)
    // {
    //     Debug.Log("It's the right exit.");
    //     game.Escape();
    // }
    protected override void Open(EscapeGame game)
    {
        Debug.Log ("It's the right exit.");
        game.Escape();
    }
}
