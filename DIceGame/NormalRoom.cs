using UnityEngine;

public class NormalRoom : RoomBase
{
    public override void OnEnter()
    {
        Debug.Log($"Normal Room entered! ({gridX}, {gridZ})");
    }
}