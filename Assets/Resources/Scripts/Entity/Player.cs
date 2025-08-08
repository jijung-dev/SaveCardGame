using UnityEngine;
using UnityEngine.UI;

public class Player : Entity
{
	private Card _card;
	public void SelectCard(Card card)
	{
		UnSelectCard();
		_card = card;

		//TEST:
		_card.transform.GetComponent<Image>().color = Color.red;
		//
	}
	public void UnSelectCard()
	{
		//TEST:
		if (_card != null)
			_card.transform.GetComponent<Image>().color = Color.white;
		//

		_card = null;
	}
	public void Discard()
	{
		_card.FlipDown();
		Reference.deck.Discard(_card);
		UnSelectCard();
	}
	public override void SetUp()
	{

	}

	public override void Select()
	{
		throw new System.NotImplementedException();
	}

	public override void UnSelect()
	{
		throw new System.NotImplementedException();
	}
}
