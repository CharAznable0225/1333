using UnityEngine;

public class TreasureRoom : RoomBase
{
    public override void OnEnter()
    {
        Debug.Log($"Treasure Room found! ({gridX}, {gridZ})");
    }
}