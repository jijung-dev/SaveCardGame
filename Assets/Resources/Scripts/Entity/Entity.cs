using PrimeTween;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public class Entity : MonoBehaviour
{
	public EntityData data;
	[HideInInspector]
	public GameTile container;
	[SerializeField]
	private RadialLayout layout;
	[SerializeField]
	private GameObject actionButton;
	public Vector2Int celPosition => container.celPosition;
	void Awake()
	{
		container = (Vector2Int)transform.position.RoundToInt();
		EntityManager.Add(this);

		SetUp();
	}
	public void SetUp()
	{
		foreach (var item in data.actions)
		{
			var button = Instantiate(actionButton, layout.transform).GetComponent<Button>();
			button.onClick.AddListener(() => SelectAction(item));
		}
		layout.gameObject.SetActive(false);
	}
	public virtual void SelectAction(PlayActionData action)
	{
		if (action.instant)
		{
			//Add Run() to ActionQueue
			return;
		}

		HoverSystem.instance.SetAction(action, celPosition);
	}
	public void Select()
	{
		layout.gameObject.SetActive(true);
		Tween.Custom(
			0f, 0.8f,
			duration: 0.2f,
			onValueChange: val =>
			{
				layout.fDistance = val;
				layout.Rebuild();
			},
			ease: Ease.OutSine
		);
	}
	public void UnSelect()
	{
		Tween.Custom(
			0.8f, 0f,
			duration: 0.2f,
			onValueChange: val =>
			{
				layout.fDistance = val;
				layout.Rebuild();
			},
			ease: Ease.InSine
		).OnComplete(() => { layout.gameObject.SetActive(false); });
	}

	//Select Entity show actions

	//Select action for AreaSelector

	//Spawn areaSpot for AreaSelector
}
