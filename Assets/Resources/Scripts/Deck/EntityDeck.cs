public class EntityDeck : CardContainer
{
	public Card[] cards => _cards.ToArray();
}