using UnityEngine;

public class RoomBase : MonoBehaviour
{
    public int gridX;
    public int gridZ;

    public virtual void Init(int x, int z)
    {
        gridX = x;
        gridZ = z;
    }

    public virtual void OnEnter()
    {
        Debug.Log($"Entered Room ({gridX}, {gridZ})");
    }
}