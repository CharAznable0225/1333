using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    private MapManager map;
    private RoomBase currentRoom;

    void Start()
    {
        map = Object.FindFirstObjectByType<MapManager>();

        
        currentRoom = map.startRoom;
        transform.position = currentRoom.transform.position + Vector3.up * 1.1f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) MoveToRoom(0, 1);
        if (Input.GetKeyDown(KeyCode.S)) MoveToRoom(0, -1);
        if (Input.GetKeyDown(KeyCode.A)) MoveToRoom(-1, 0);
        if (Input.GetKeyDown(KeyCode.D)) MoveToRoom(1, 0);
    }

    void MoveToRoom(int moveX, int moveZ)
    {
        int newX = currentRoom.gridX + moveX;
        int newZ = currentRoom.gridZ + moveZ;

        RoomBase nextRoom = map.GetRoom(newX, newZ);

        if (nextRoom == null)
            return;

        currentRoom = nextRoom;

        float spacing = map.GetSpacing();

        Vector3 newPos = new Vector3(newX * spacing, 1.1f, newZ * spacing);
        transform.position = newPos;

        currentRoom.OnEnter();
    }
}