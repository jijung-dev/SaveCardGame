using System.Collections;
using UnityEngine;

public abstract class PlayActionData : ScriptableObject
{
	public Area area;
	public Area hoverArea;
	public bool instant;
	[HideInInspector]
	public Entity owner;
	public abstract IEnumerator Run(Vector2Int center);
}
