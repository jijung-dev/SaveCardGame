using PrimeTween;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public abstract class Entity : MonoBehaviour
{
	public EntityData data;
	[HideInInspector]
	public GameTile container;
	public Vector2Int celPosition => container.celPosition;
	void Awake()
	{
		container = (Vector2Int)transform.position.RoundToInt();
		EntityManager.Add(this);

		SetUp();
	}
	public abstract void SetUp();
	public virtual void SelectAction(PlayActionData action)
	{
		if (action.instant)
		{
			ActionQueue.Stack(action, Vector2Int.one * 10000);
			return;
		}

		HoverSystem.instance.SetAction(action, celPosition);
	}
	public abstract void Select();
	public abstract void UnSelect();
	public virtual void Destroy()
	{
		EntityManager.Remove(this);
		Destroy(this.gameObject);
	}

	//Select Entity show actions

	//Select action for AreaSelector

	//Spawn areaSpot for AreaSelector
}
