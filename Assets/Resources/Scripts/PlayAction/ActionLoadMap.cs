using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "New Map Loader", menuName = "Action/LoadMap")]
public class ActionLoadMap : PlayActionData
{
	public override IEnumerator Run(Vector2Int center)
	{
		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MapScene");
		while (!asyncLoad.isDone)
		{
			yield return null;
		}
	}
}