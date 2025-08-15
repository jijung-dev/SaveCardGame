using System.Collections;
using EditorAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleInitiator : MonoBehaviourSingleton<BattleInitiator>
{
	[SerializeField]
	private BattleData _data;
	[SerializeField]
	private DeckData _deckData;
	[Button(true)]
	public void ChooseBattle()
	{
		StartCoroutine(LoadBattleAsync());
	}
	private IEnumerator LoadBattleAsync()
	{
		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("BattleScene");
		while (!asyncLoad.isDone)
		{
			yield return null;
		}
		InitBattle();
	}
	public void InitBattle()
	{
		if (_data is null) { DebugExt.LogError("No Battle Data found", this); return; }
		Events.InvokeOnBattleInit(_data);

		Reference.battleSystem.data = _data;
		Reference.deck.data = _deckData;
		Reference.battleSystem.BattleSetUp();
	}
}