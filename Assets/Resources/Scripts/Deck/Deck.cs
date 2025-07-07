using System.Collections.Generic;
using UnityEngine;

public class Deck : CardContainer
{
    [SerializeField]
    private DrawPile drawPile;
    [SerializeField]
    private DiscardPile discardPile;
    [SerializeField]
    private CardContainer handPile;

    public int handSize;

    //TEST:
    public List<Card> cards;

    public void TESTADDCARD()
    {
        _cards = cards;
    }
    //
    public void Populate()
    {
        TESTADDCARD();
        drawPile.Add(_cards.ToArray());
    }

    public void Draw()
    {
        for (int i = 1; i < _cards.Count - handSize; i++)
        {
            if (drawPile.Count <= 0)
                drawPile.Add(discardPile.PullAll());
            handPile.Add(drawPile.Pull());
        }
    }
}
