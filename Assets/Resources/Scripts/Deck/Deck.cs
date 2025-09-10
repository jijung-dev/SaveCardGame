using System.Collections.Generic;
using System.Linq;
using PrimeTween;
using UnityEngine;

public class Deck : CardContainer
{
    [SerializeField]
    private DrawPile drawPile;
    [SerializeField]
    private DiscardPile discardPile;
    [SerializeField]
    private HandPile handPile;
    [SerializeField]
    private HandPile actionPile;
    [SerializeField]
    private Transform deckParent;
    [SerializeField]
    private Transform entityDeckParent;
    public int handSize;

    [HideInInspector]
    public DeckData data;

    public void SetUp()
    {
        Events.OnTurnEnd += Draw;
        Tween.PositionY(deckParent, 100f, duration: 1f, Ease.OutElastic);
        Populate();
        Draw();
    }

    public void PopulateAlly()
    {
        List<Vector2Int> spawnableTile = Battle.battleSystem.data.allySpawnable.ToList();
        foreach (var item in data.allies)
        {
            GameTile tile = spawnableTile.RandomItem();
            Battle.entityManager.entitySpawner.SpawnPhantom(item, tile);
            spawnableTile.Remove(tile.celPosition);
        }
    }
    public void PopulateEntitySkill(EntityDeck deck)
    {
        var pullAmount = deck.Count;
        for (int i = 0; i < pullAmount; i++)
        {
            var card = deck.Pull();

            actionPile.Add(card);
            card.Enable();
        }
        deckParent.gameObject.SetActive(false);
        entityDeckParent.gameObject.SetActive(true);
        Tween.PositionY(entityDeckParent, startValue: -200f, endValue: 100f, duration: 1f, Ease.OutElastic);
    }
    public void UnSelect()
    {
        deckParent.gameObject.SetActive(true);
        entityDeckParent.gameObject.SetActive(false);
        Tween.PositionY(deckParent, startValue: -200f, endValue: 100f, duration: 1f, Ease.OutElastic);
    }
    public void Populate()
    {
        foreach (var item in data.cards)
        {
            var card = Battle.entityManager.entitySpawner.SpawnCard(item);
            card.data.action.owner = Battle.player;

            drawPile.Add(card);
        }
        _cards.Clear();
    }

    public void Draw()
    {
        discardPile.Add(handPile.PullAll());

        for (int i = handPile.Count; i < handSize - 1; i++)
        {
            if (drawPile.Count <= 0)
                drawPile.Add(discardPile.PullAll());

            var card = drawPile.Pull();
            handPile.Add(card);

            card.Enable();
        }
    }
    public void Discard(Card card)
    {
        card.Disable();
        handPile.Remove(card);
        discardPile.Add(card);
    }
}
