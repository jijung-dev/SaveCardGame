using System.Collections.Generic;
using PrimeTween;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public class Ally : Entity
{
    private Card[] _actionCards;
    public override void SetUp()
    {
        base.SetUp();
        var cards = new List<Card>();
        foreach (var item in data.actions)
        {
            item.action.owner = this;
            var card = Reference.entitySpawner.SpawnCard(item);
            card.transform.SetParent(transform);
            card.FlipUp();
            cards.Add(card);
        }
        _actionCards = cards.ToArray();
    }

    public override void UnSelect()
    {
        base.UnSelect();
        Reference.deck.UnSelect();
        foreach (var item in _actionCards)
        {
            item.transform.SetParent(transform);
        }
    }

    public override void Select()
    {
        base.Select();
        Reference.deck.PopulateEntitySkill(_actionCards);
    }
}
