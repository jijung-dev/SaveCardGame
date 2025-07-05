using System.Collections.Generic;
using UnityEngine;

public class CardContainer : MonoBehaviour
{
    protected List<Card> _cards = new List<Card>();

    public virtual void Add(params Card[] cards)
    {
        _cards.AddRange(cards);
    }
    public virtual Card Pull()
    {
        if (_cards.Count <= 0)
            return null;
            
        var ranCard = _cards.RandomItem();
        _cards.Remove(ranCard);
        return ranCard;
    }
    public virtual void Remove(Card card)
    {
        _cards.Remove(card);
    }
}
