using PrimeTween;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HandPile : CardContainer
{
	public override void Add(params Card[] cards)
	{
		foreach (var card in cards)
		{
			card.display.scale = 1f;
			card.display.promptUpdate = true;
		}
		base.Add(cards);
	}
}
