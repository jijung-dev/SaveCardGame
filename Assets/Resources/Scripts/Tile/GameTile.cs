using UnityEngine;

public class GameTile : MonoBehaviour
{
    //TileData
    public Vector3Int celPosition { get; private set; }

    void Awake()
    {
        celPosition = transform.position.FloorToInt();

        TileManager.Add(this);
	}
}
