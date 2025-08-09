using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleInitiator : MonoBehaviourSingleton<BattleInitiator>
{
	[SerializeField]
	private BattleData _data;
	[SerializeField]
	private DeckData _deckData;
	public void ChooseBattle()
	{
		SceneManager.LoadScene("BattleScene");
	}
	public void InitBattle()
	{
		Reference.battleSystem.data = _data;
		Reference.deck.data = _deckData;
		Reference.battleSystem.BattleSetUp();
	}
}