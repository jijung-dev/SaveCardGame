using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "New Main Menu Loader", menuName = "Action/LoadMainMenu")]
public class ActionLoadMainMenu : PlayActionData
{
	public override IEnumerator Run(Vector2Int center)
	{
		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MainMenuScene");
		while (!asyncLoad.isDone)
		{
			yield return null;
		}
	}
}