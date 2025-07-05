using UnityEngine;

public class DiscardPile : CardContainer
{
	public Card[] PullAll()
	{
		var cards = _cards.ToArray();
		_cards.Clear();
		return cards;
	}
}
