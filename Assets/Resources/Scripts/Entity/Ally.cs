using System.Collections.Generic;
using PrimeTween;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public class Ally : Entity
{
    [SerializeField]
    private EntityDeck _deck;
    public EntityDeck deck => _deck;
    public override void SetUp()
    {
        base.SetUp();
        foreach (var cardData in data.actions)
        {
            var card = Reference.entitySpawner.SpawnCard(cardData);
            card.data.action.owner = this;
            card.transform.SetParent(transform);
            _deck.Add(card);
        }
    }

    public override void UnSelect()
    {
        base.UnSelect();
        Reference.deck.UnSelect();
        foreach (var card in _deck.cards)
        {
            card.Disable();
            card.container = null;
            card.transform.SetParent(transform);
        }
    }

    public override void Select()
    {
        base.Select();
        Reference.deck.PopulateEntitySkill(_deck);
    }
}
