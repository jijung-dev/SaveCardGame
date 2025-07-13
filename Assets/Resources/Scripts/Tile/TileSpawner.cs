using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject tilePrefab;
    //Different tile type

    public void Spawn(BattleData data)
    {
        var offset = new Vector2Int((int)(data.boardSize.x / 2 - 0.5f), (int)(data.boardSize.y / 2 - 0.5f));
        for (int x = -offset.x; x <= offset.x; x++)
        {
            for (int y = -offset.y; y <= offset.y; y++)
            {
                Instantiate(tilePrefab, new Vector2(x, y), Quaternion.identity, transform);
            }
        }
    }

}
