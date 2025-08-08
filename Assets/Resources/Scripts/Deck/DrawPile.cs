using UnityEngine;

public class DrawPile : CardContainer
{
	public override Card Pull()
	{
		var card = base.Pull();
		card.FlipUp();
		return card;
	}
}
