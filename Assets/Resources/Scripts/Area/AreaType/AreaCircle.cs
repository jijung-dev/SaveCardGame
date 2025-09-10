using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New AreaCircle", menuName = "Area/AreaCircle")]
public class AreaCircle : AreaData
{
    public override Vector2Int[] GetTile(Vector2Int center, int size, TileConstraint constraint)
    {
        List<Vector2Int> hitTiles = new List<Vector2Int>();
        //int rSquared = size * size;

        Vector2Int min = (center - Vector2.one * size).RoundToInt();
        Vector2Int max = (center + Vector2.one * size).RoundToInt();

        for (int x = min.x; x <= max.x; x++)
        {
            for (int y = min.y; y <= max.y; y++)
            {
                Vector2Int cellPos = new Vector2Int(x, y);

                // if (!isIncludedSelf && cellPos == center)
                //     continue;

                // Check if the center of the tile is within the circle
                if (Vector3.Distance((Vector3Int)center, (Vector3Int)cellPos) - 0.5f <= size)
                {
                    if (!Battle.tileManager.HasTile(cellPos))
                        continue;
                    if (constraint == null || !constraint.Check(cellPos))
                        continue;

                    hitTiles.Add(cellPos);
                }
            }
        }

        return hitTiles.ToArray();
    }
}
