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
    private CardContainer handPile;
    [SerializeField]
    private Transform deckParent;
    public int handSize;

    [HideInInspector]
    public DeckData data; 

    public void SetUp()
    {
        Tween.PositionY(deckParent, 80f, duration: 1f, Ease.OutElastic);
        Populate();
        Draw();
    }

    public void PopulateAlly()
    {
        //FIXME: Spawn on the same tile
        var spawnableTile = Reference.battleSystem.data.allySpawnable;
        foreach (var item in data.allies)
        {
            GameTile tile = spawnableTile.RandomItem();
            Reference.entitySpawner.SpawnPhantom(item, tile);
            spawnableTile.Remove(tile.celPosition);
        }
    }
    public void Populate()
    {
        foreach (var item in data.cards)
        {
            var card = Reference.entitySpawner.SpawnCard(item);
            Add(card);
        }
        drawPile.Add(_cards.ToArray());
        _cards.Clear();
    }

    public void Draw()
    {
        for (int i = handPile.Count; i < handSize - 1; i++)
        {
            if (drawPile.Count <= 0)
                drawPile.Add(discardPile.PullAll());
            handPile.Add(drawPile.Pull());
        }
    }
    public void Discard(Card card)
    {
        handPile.Remove(card);
        discardPile.Add(card);
    }
}
