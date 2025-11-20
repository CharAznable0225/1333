using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject normalRoomPrefab;
    public GameObject encounterRoomPrefab;
    public GameObject treasureRoomPrefab;

    private RoomBase[,] grid;

    public int gridWidth = 3;
    public int gridHeight = 3;

    
    public float roomSpacing = 12f;

    public RoomBase startRoom;

    void Start()
    {
        GenerateMap();
    }

    void GenerateMap()
    {
        grid = new RoomBase[gridWidth, gridHeight];

        for (int x = 0; x < gridWidth; x++)
        {
            for (int z = 0; z < gridHeight; z++)
            {
                GameObject roomObj;

                if (x == 1 && z == 1)
                    roomObj = Instantiate(encounterRoomPrefab);
                else if (x == 2 && z == 2)
                    roomObj = Instantiate(treasureRoomPrefab);
                else
                    roomObj = Instantiate(normalRoomPrefab);

                
                roomObj.transform.position =
                    new Vector3(x * roomSpacing, 0, z * roomSpacing);

                RoomBase room = roomObj.GetComponent<RoomBase>();
                room.Init(x, z);

                grid[x, z] = room;

                if (x == 0 && z == 0)
                    startRoom = room;
            }
        }
    }

    public RoomBase GetRoom(int x, int z)
    {
        if (x < 0 || x >= gridWidth || z < 0 || z >= gridHeight)
            return null;

        return grid[x, z];
    }

    public float GetSpacing()
    {
        return roomSpacing;
    }
}
