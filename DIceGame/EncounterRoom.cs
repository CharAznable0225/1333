using UnityEngine;

public class EncounterRoom : RoomBase
{
    protected override void SpawnVisual()
    {
        RoomName = "Encounter Room";
        var renderer = GetComponent<Renderer>();
        if (renderer != null) renderer.material.color = Color.red;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        Debug.Log("Battle begins!");
    }
}