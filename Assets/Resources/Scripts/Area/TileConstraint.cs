using System;
using UnityEngine;

public abstract class TileConstraint : ScriptableObject
{
	public bool not;
	public abstract bool Check(Vector2Int pos);
}