using System.Collections;
using UnityEngine;

public abstract class PlayActionData : ScriptableObject
{
	public Area area;
	public Area hoverArea;
	public bool instant;
	public abstract IEnumerator Run();
}
