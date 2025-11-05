using UnityEngine;

public class MapManager : MonoBehaviour
{
    [Tooltip("Keep small for testing: 3~8")]
    public int mapSize = 5;

    public GameObject normalRoomPrefab;
    public GameObject treasureRoomPrefab;
    public GameObject encounterRoomPrefab;

    [HideInInspector] public RoomBase[,] rooms;
    [HideInInspector] public RoomBase startRoom;

    public void CreateMap()
    {
        if (normalRoomPrefab == null || treasureRoomPrefab == null || encounterRoomPrefab == null)
        {
            Debug.LogError("[MapManager] One or more room prefabs are not assigned!");
            return;
        }

        if (mapSize < 1) mapSize = 1;
        if (mapSize > 25)
        {
            Debug.LogWarning("[MapManager] mapSize too large, clamped to 25 for safety.");
            mapSize = 25;
        }

        rooms = new RoomBase[mapSize, mapSize];
        int created = 0;

        for (int x = 0; x < mapSize; x++)
        {
            for (int z = 0; z < mapSize; z++)
            {
                GameObject prefab;

                if ((x + z) % 3 == 0)
                    prefab = treasureRoomPrefab;
                else if ((x + z) % 2 == 0)
                    prefab = encounterRoomPrefab;
                else
                    prefab = normalRoomPrefab;

                float roomSpacing = 10f;
                Vector3 pos = new Vector3(x * roomSpacing, 0f, z * roomSpacing);
                GameObject go = Instantiate(prefab, pos, Quaternion.identity, transform);

                Debug.Log($"[MapManager] Spawned {prefab.name} at {pos}");



                RoomBase rb = go.GetComponent<RoomBase>();
                if (rb == null)
                {
                    Debug.LogError($"[MapManager] Prefab {prefab.name} lacks RoomBase component!");
                    Destroy(go);
                    continue;
                }

                rb.Initialize(x, z);
                rooms[x, z] = rb;
                created++;
            }
        }

        
        int startX = Mathf.Min(1, mapSize - 1);
        int startZ = Mathf.Min(1, mapSize - 1);
        startRoom = rooms[startX, startZ];
        startRoom.isStartRoom = true;

        Debug.Log($"[MapManager] Created {created} rooms ({mapSize}x{mapSize}).");
        Debug.Log($"[MapManager] Start room set at ({startX},{startZ})");
    }

    public RoomBase GetRoom(int x, int z)
    {
        if (rooms == null) return null;
        if (x < 0 || x >= rooms.GetLength(0) || z < 0 || z >= rooms.GetLength(1)) return null;
        return rooms[x, z];
    }
}
