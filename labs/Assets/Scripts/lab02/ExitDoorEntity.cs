using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoorEntity : DoorEntity
{
    public ExitDoorEntity (EscapeGame game, string name, string identifier, Vector3 position)
    : base (game, name, identifier, position) {}
    public override void Interact(Entity entity = null)
    {
        Debug.Log("It's the right exit.");
        Game.Escape();
    }
    protected override void Open()
    {
        Debug.Log ("It's the right exit.");
        Game.Escape();
    }
}
