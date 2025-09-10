using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "New Battle Loader", menuName = "Action/LoadBattle")]
public class ActionLoadBattle : PlayActionData
{
	[Header("Battle Data")]
	[SerializeField]
	private BattleData _data;
	//TODO: Move deck data to CampaignSystem or Player to hold
	[SerializeField]
	private DeckData _deckData;
	public override IEnumerator Run(Vector2Int center)
	{
		// Now load the battle scene fresh
		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("BattleScene", LoadSceneMode.Single);
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

		Battle.battleSystem.data = _data;
		Battle.deck.data = _deckData;
		Battle.battleSystem.BattleSetUp();
	}
}