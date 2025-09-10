using UnityEngine;

public class GameTile : MonoBehaviour
{
    //TileData
    public Vector2Int celPosition { get; private set; }

    public static implicit operator GameTile(Vector2Int Vector2Int) => Battle.tileManager.GetTile(Vector2Int);
    public static implicit operator Vector2Int(GameTile GameTile) => GameTile.celPosition;

    void Awake()
    {
        celPosition = (Vector2Int)transform.position.RoundToInt();

        Battle.tileManager.Add(this);
    }
    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
