using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New AreaOneTile", menuName = "Area/AreaOneTile")]
public class AreaOneTile : AreaData
{
    public override Vector2Int[] GetTile(Vector2Int center, int size)
    {
        return new[] { center };
    }
}
