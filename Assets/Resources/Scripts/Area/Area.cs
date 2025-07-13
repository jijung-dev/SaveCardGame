using System;
using UnityEngine;

[Serializable]
public class Area
{
    public int size;
    public AreaData area;
    public Vector2Int[] GetTile(Vector2Int center) => area.GetTile(center, size);
}
