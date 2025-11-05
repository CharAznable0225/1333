using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private MapManager mapManager;
    private Rigidbody rb;
    private int gridX = 0;
    private int gridZ = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null) rb = gameObject.AddComponent<Rigidbody>();

        mapManager = FindFirstObjectByType<MapManager>();
        if (mapManager == null)
        {
            Debug.LogError("[PlayerController] MapManager not found in scene!");
            return;
        }

        

        
        var startRoom = mapManager.startRoom;
        if (startRoom != null)
        {
            gridX = startRoom.X;
            gridZ = startRoom.Z;
            transform.position = new Vector3(gridX, 0.5f, gridZ);
            startRoom.OnEnter();
        }
        else
        {
            transform.position = new Vector3(0, 0.5f, 0);
            Debug.LogWarning("[PlayerController] Start room not found; player placed at origin.");
        }
    }

    void Update()
    {
        if (mapManager == null) return;

        int newX = gridX;
        int newZ = gridZ;

        if (Input.GetKeyDown(KeyCode.W)) newZ += 1;
        if (Input.GetKeyDown(KeyCode.S)) newZ -= 1;
        if (Input.GetKeyDown(KeyCode.A)) newX -= 1;
        if (Input.GetKeyDown(KeyCode.D)) newX += 1;

        if (newX != gridX || newZ != gridZ)
        {
            var room = mapManager.GetRoom(newX, newZ);
            if (room != null)
            {
                gridX = newX;
                gridZ = newZ;
                transform.position = new Vector3(gridX, 0.5f, gridZ);
                room.OnEnter();
            }
            else
            {
                Debug.Log("[PlayerController] Can't move there (out of map).");
            }
        }
    }
}