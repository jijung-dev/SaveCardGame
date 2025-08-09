using System;
using EditorAttributes;
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
	public Health health;
	[SerializeField]
	private HealthDisplay display;

	//TEST:
	[Button(true)]
	public void Hitting()
	{
		health.Hit(1);
		display.promptUpdate = true;
	}
	[Button(true)]
	public void Healing()
	{
		health.Heal(1);
		display.promptUpdate = true;
	}
	//

	void Awake()
	{
		container = (Vector2Int)transform.position.RoundToInt();
		EntityManager.Add(this);

		SetUp();
	}
	public virtual void SetUp()
	{
		health = new Health();
		health.SetUp(5);
		display.promptUpdate = true;
	}
	public virtual void SelectAction(PlayActionData action)
	{
		if (action.instant)
		{
			ActionQueue.Stack(action, Vector2Int.one * 10000);
			return;
		}

		Reference.hoverSystem.SetAction(action, celPosition);
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
