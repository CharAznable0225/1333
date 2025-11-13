using UnityEngine;
using System.Collections;

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

       
        StartCoroutine(WaitForMap());
    }

    private IEnumerator WaitForMap()
    {
        mapManager = FindFirstObjectByType<MapManager>();

        
        while (mapManager == null || mapManager.startRoom == null)
        {
            yield return null;
            mapManager = FindFirstObjectByType<MapManager>();
        }

        Debug.Log("[PlayerController] Map ready, initializing player...");

        var startRoom = mapManager.startRoom;
        gridX = startRoom.X;
        gridZ = startRoom.Z;

        
        transform.position = new Vector3(gridX * 10f, 0.5f, gridZ * 10f);
        startRoom.OnEnter();
    }

    void Update()
    {
        if (mapManager == null || mapManager.rooms == null)
            return;

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
                transform.position = new Vector3(gridX * 10f, 0.5f, gridZ * 10f);
                room.OnEnter();
            }
            else
            {
                Debug.Log("[PlayerController] Can't move there (out of map).");
            }
        }
    }
}