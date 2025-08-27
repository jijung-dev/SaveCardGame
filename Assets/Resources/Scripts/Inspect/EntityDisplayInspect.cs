using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class EntityDisplayInspect : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI title;
	[SerializeField]
	private Image sprite;
	[SerializeField]
	private TextMeshProUGUI desc;
	private Entity _entity;
	private EntityData _data;
	public bool promptUpdate;
	public void SetData(Entity entity)
	{
		_entity = entity;
		_data = entity.data;
		promptUpdate = true;
	}
	void Update()
	{
		if (promptUpdate)
		{
			promptUpdate = false;
			UpdateDisplay();
		}
	}

	void UpdateDisplay()
	{
		title.text = _data.title;
		sprite.sprite = _data.sprite;
		desc.text = _data.description;
	}
	public void OpenDeck()
	{
		if (_entity is Ally ally)
		{
			Reference.inspectSystem.containerDisplay.Open(ally.deck);
		}
	}
}