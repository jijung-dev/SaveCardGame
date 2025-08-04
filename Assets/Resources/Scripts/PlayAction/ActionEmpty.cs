using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "Test", menuName = "Action")]
public class ActionEmpty : PlayActionData
{
	public override IEnumerator Run(Vector2Int center)
	{
		Debug.Log($"Lmao at {center}");
		yield return null;
	}
}