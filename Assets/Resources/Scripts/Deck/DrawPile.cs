using UnityEngine;

public class DrawPile : CardContainer
{
	public int Count => _cards.Count;
	public override Card Pull()
	{
		var card = base.Pull();
		card.FlipUp();
		return card;
	}
}
