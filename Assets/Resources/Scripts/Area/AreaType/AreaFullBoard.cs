using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "New AreaFullBoard", menuName = "Area/AreaFullBoard")]
public class AreaFullBoard : AreaData
{
    public override Vector2Int[] GetTile(Vector2Int center, int size, TileConstraint constraint)
    {
        List<Vector2Int> hitTiles = new List<Vector2Int>();
        foreach (var item in TileManager.tiles.Keys)
        {
            if (constraint != null && constraint.Check(item))
                hitTiles.Add(item);
        }

        return hitTiles.ToArray();
    }
}
