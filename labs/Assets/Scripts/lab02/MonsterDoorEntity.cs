using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDoorEntity : DoorEntity
{
    public MonsterDoorEntity (EscapeGame game, string name, string identifier, Vector3 position)
    : base (game, name, identifier, position) {}
    protected override void Open()
    {
        Debug.Log("<color=red>You release a monster.</color>");
        Game.Die();
    }
}
