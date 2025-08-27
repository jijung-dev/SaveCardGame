using UnityEngine;
using UnityEngine.EventSystems;

public class ContainerDisplay : MonoBehaviour
{
	private CardContainer _containerClose;
	[SerializeField]
	private CardContainer containerOpen;
	[SerializeField]
	private GameObject openPanel;

	public void Open(CardContainer containerClose)
	{
		_containerClose = containerClose;
		var cards = _containerClose.PullAll();
		foreach (var card in cards)
		{
			containerOpen.Add(card);
			card.display.scale = 1f;
			card.display.promptUpdate = true;
			card.isHoverable = true;
		}
		openPanel.SetActive(true);
	}
	public void Close()
	{
		var cards = containerOpen.PullAll();
		foreach (var card in cards)
		{
			_containerClose.Add(card);
			card.display.scale = 0.5f;
			card.display.promptUpdate = true;
			card.Disable();
		}
		_containerClose = null;
		openPanel.SetActive(false);
	}
}