using UnityEngine;

public class EncounterRoom : RoomBase
{
    private Color color = Color.red;

    protected override void SpawnVisual()
    {
        Visual = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Visual.transform.position = new Vector3(X, 0, Z);
        Visual.transform.localScale = Vector3.one * 0.95f;
        Visual.GetComponent<Renderer>().material.color = color;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        Debug.Log("EncounterRoom!");
    }
}