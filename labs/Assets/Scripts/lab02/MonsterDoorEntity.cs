using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDoorEntity : DoorEntity
{
    public MonsterDoorEntity (string name, string identifier = null) : base (name, identifier) {}
    protected override void Open(EscapeGame game)
    {
        Debug.Log("<color=red>You release a monster.</color>");
        game.Die();
    }
}
