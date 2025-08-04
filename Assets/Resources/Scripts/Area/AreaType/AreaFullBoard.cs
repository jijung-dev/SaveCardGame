using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "New AreaFullBoard", menuName = "Area/AreaFullBoard")]
public class AreaFullBoard : AreaData
{
    public override Vector2Int[] GetTile(Vector2Int center, int size)
    {
        List<Vector2Int> hitTiles = new List<Vector2Int>();
        hitTiles.AddRange(TileManager.tiles.Keys);

        return hitTiles.ToArray();
    }
}
