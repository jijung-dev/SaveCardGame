using UnityEngine;

public static class VectorExt
{
    public static Vector3Int RoundToInt(this Vector3 vector)
    {
        return Vector3Int.RoundToInt(vector);
    }
    public static Vector2Int RoundToInt(this Vector2 vector)
    {
        return Vector2Int.RoundToInt(vector);
    }
}
