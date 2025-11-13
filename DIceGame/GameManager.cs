using UnityEngine;

public class GameManager : MonoBehaviour
{
    public MapManager mapManager;

    private void Start()
    {
        if (mapManager != null)
        {
            mapManager.CreateMap();
        }
        else
        {
            Debug.LogError("[GameManager] MapManager not assigned!");
        }
    }
}