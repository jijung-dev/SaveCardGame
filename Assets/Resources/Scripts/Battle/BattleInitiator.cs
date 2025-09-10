using System.Collections;
using EditorAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleInitiator : MonoBehaviourSingleton<BattleInitiator>
{
	[SerializeField]
	private ActionLoadBattle battleLoad;
	[Button(true)]
	public void ChooseBattle()
	{
		ActionQueue.Stack(battleLoad, Vector2Int.one * 10000);
	}
}