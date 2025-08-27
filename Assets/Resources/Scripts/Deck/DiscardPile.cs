using UnityEngine;

public class DiscardPile : CardContainer
{
	public override void Add(params Card[] cards)
	{
		foreach (var card in cards)
		{
			card.display.scale = 0.5f;
			card.display.promptUpdate = true;
		}
		base.Add(cards);
	}
}
