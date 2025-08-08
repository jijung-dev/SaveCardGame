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
        _cards.Remove(card);
        return card;
    }
    public virtual Card PullRandom()
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
