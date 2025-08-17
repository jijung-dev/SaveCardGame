using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardContainer : MonoBehaviour
{
    protected List<Card> _cards = new List<Card>();
    public int Count => _cards.Count;

    public virtual void Add(params Card[] cards)
    {
        foreach (var item in cards)
        {
            item.container = this;
            item.transform.SetParent(transform);
            item.transform.position = transform.position;
        }
        _cards.AddRange(cards);
    }
    public virtual Card Pull()
    {
        if (_cards.Count <= 0)
            return null;
            
        var card = _cards.First();
        Remove(card);
        return card;
    }
    public virtual void Remove(Card card)
    {
        card.container = null;
        _cards.Remove(card);
    }
}
