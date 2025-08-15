using EditorAttributes;
using UnityEngine;
public class TurnSystem : MonoBehaviour
{
	[Button(true)]
	public void EndTurn()
	{
		Events.InvokeOnTurnEnd();
	}
}