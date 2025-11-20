using UnityEngine;

public class EncounterRoom : RoomBase
{
    public override void OnEnter()
    {
        Debug.Log($"Encounter Room entered! ({gridX}, {gridZ})");
    }
}
