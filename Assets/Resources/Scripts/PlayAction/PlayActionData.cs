using System.Collections;
using UnityEngine;

public abstract class PlayActionData : ScriptableObject
{
	public Area area;
	public Area hoverArea;
	public bool instant;
	public Entity owner;
	public int cost;
	public abstract IEnumerator Run(Vector2Int center);
}
