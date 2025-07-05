using UnityEngine;

public class Deck : CardContainer
{
    [SerializeField]
    private DrawPile drawPile;
    [SerializeField]
    private DiscardPile discardPile;

    public int handSize;

    public void Draw()
    {
        for (int i = 0; i < _cards.Count - handSize; i++)
        {
            if (drawPile.Count <= 0)
                drawPile.Add(discardPile.PullAll());
            Add(drawPile.Pull());
        }
    }
}
