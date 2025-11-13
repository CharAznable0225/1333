using UnityEngine;

public abstract class RoomBase : MonoBehaviour
{
    public string RoomName = "Room";

    
    public int X { get; private set; }
    public int Z { get; private set; }

    
    public int gridX => X; 
    public int gridZ => Z;
    public bool isStartRoom = false;

    protected GameObject Visual;

    
    public void Initialize(int x, int z)
    {
        X = x;
        Z = z;
        SpawnVisual();
    }

    
    public virtual void OnEnter()
    {
        if (isStartRoom)
            Debug.Log($"[RoomBase] Entered START ROOM at ({X},{Z})");
        else
            Debug.Log($"Entered {RoomName} at ({X},{Z})");
    }

    
    protected abstract void SpawnVisual();
}