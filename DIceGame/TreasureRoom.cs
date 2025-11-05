using UnityEngine;

public class TreasureRoom : RoomBase
{
    private Color color = Color.yellow;

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
        Debug.Log("You found treasure!");
    }
}
