using UnityEngine;

public abstract class AreaData : ScriptableObject
{
	public abstract Vector2Int[] GetTile(Vector2Int center, int size);
}