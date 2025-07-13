using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "Test", menuName = "Action")]
public class ActionEmpty : PlayActionData
{
	public override IEnumerator Run()
	{
		Debug.Log("Lmao");
		yield return null;
	}
}