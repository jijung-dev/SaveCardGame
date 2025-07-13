using UnityEngine;

public class GameTile : MonoBehaviour
{
    //TileData
    public Vector2Int celPosition { get; private set; }

    public static implicit operator GameTile(Vector2Int Vector2Int) => TileManager.GetTile(Vector2Int);

    void Awake()
    {
        celPosition = (Vector2Int)transform.position.RoundToInt();

        TileManager.Add(this);
    }
}
